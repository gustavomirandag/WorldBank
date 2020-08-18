using IdentityModel.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using WorldBank.App.Application.Models.Dtos;
using WorldBank.App.Application.Models.ViewModels.TransactionAggregate;

namespace WorldBank.App.Application
{
    public class ApplicationService
    {
        private static string token;

        //WorldBankMobileApp_ClientId
        public ObservableCollection<TransactionViewModel> Statement { get; set; }

        //Casos de uso
        public async Task<ObservableCollection<TransactionViewModel>> GetWalletStatementAsync(Guid walletId)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", "bearer " + token);
            var result = await httpClient.GetAsync("https://worldbank-gustavo-transaction-microservice-api.azurewebsites.net/api/transactions/" + walletId.ToString());
            if (!result.IsSuccessStatusCode)
                return null;
            var serializedStatement = await result.Content.ReadAsStringAsync();
            var statement = JsonConvert.DeserializeObject<IEnumerable<TransactionViewModel>>(serializedStatement);

            Statement = new ObservableCollection<TransactionViewModel>(statement);
            return Statement;
        }

        //IAM Functions
        public bool SignIn(string username, string password)
        {
            token = GetToken(username, password);

            if (String.IsNullOrWhiteSpace(token))
                return false;

            return true;
        }

        public bool SignUp(UserPasswordDto userPassword)
        {
            var adminToken = GetAdminToken();
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", "bearer " + adminToken);
            var serializedUserPassword = JsonConvert.SerializeObject(userPassword);
            var httpContent = new StringContent(serializedUserPassword, Encoding.UTF8, "application/json");
            var result = httpClient.PostAsync("https://worldbank-gustavo-iam-microservice-api.azurewebsites.net/api/UsersAndRoles", httpContent).Result;

            if (!result.IsSuccessStatusCode)
                return false;
            return true;
        }

        private string GetAdminToken()
        {
            var client = new HttpClient();
            var response = client.RequestPasswordTokenAsync(new PasswordTokenRequest
            {
                Address = "https://worldbank-gustavo-iam-microservice-identity.azurewebsites.net/connect/token",

                ClientId = "WorldBankMobileApp_ClientId",
                //ClientSecret = "secret",
                //Scope = "api1",

                UserName = "admin",
                Password = "@dsInf123"
            }).Result;

            return response.AccessToken;
        }

        public string GetToken(string username, string password)
        {
            var httpClient = new HttpClient();
            var response = httpClient.RequestPasswordTokenAsync(new PasswordTokenRequest
            {
                Address = "https://worldbank-gustavo-iam-microservice-identity.azurewebsites.net/connect/token",

                ClientId = "WorldBankMobileApp_ClientId",
                //ClientSecret = "secret",
                //Scope = "api1",

                UserName = username,
                Password = password
            }).Result;

            return response.AccessToken;

        }
    }
}
