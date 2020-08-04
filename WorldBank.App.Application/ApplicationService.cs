using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using WorldBank.App.Application.Models.ViewModels.TransactionAggregate;

namespace WorldBank.App.Application
{
    public class ApplicationService
    {
        public ObservableCollection<TransactionViewModel> Statement { get; set; }

        //Casos de uso
        public async Task<ObservableCollection<TransactionViewModel>> GetWalletStatementAsync(Guid walletId)
        {
            var httpClient = new HttpClient();
            var result = await httpClient.GetAsync("http://localhost:63624/api/transactions/3a2ead22-6a54-4573-81b7-e559ce7c08b4");
            if (!result.IsSuccessStatusCode)
                return null;
            var serializedStatement = await result.Content.ReadAsStringAsync();
            var statement = JsonConvert.DeserializeObject<IEnumerable<TransactionViewModel>>(serializedStatement);

            Statement = new ObservableCollection<TransactionViewModel>(statement);
            return Statement;
        }
    }
}
