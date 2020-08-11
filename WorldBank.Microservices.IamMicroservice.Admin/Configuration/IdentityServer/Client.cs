using System.Collections.Generic;
using WorldBank.Microservices.IamMicroservice.Admin.Configuration.Identity;

namespace WorldBank.Microservices.IamMicroservice.Admin.Configuration.IdentityServer
{
    public class Client : global::IdentityServer4.Models.Client
    {
        public List<Claim> ClientClaims { get; set; } = new List<Claim>();
    }
}






