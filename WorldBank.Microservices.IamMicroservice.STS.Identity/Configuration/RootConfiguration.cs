using WorldBank.Microservices.IamMicroservice.Shared.Configuration.Identity;
using WorldBank.Microservices.IamMicroservice.STS.Identity.Configuration.Interfaces;

namespace WorldBank.Microservices.IamMicroservice.STS.Identity.Configuration
{
    public class RootConfiguration : IRootConfiguration
    {      
        public AdminConfiguration AdminConfiguration { get; } = new AdminConfiguration();
        public RegisterConfiguration RegisterConfiguration { get; } = new RegisterConfiguration();
    }
}





