using WorldBank.Microservices.IamMicroservice.Shared.Configuration.Identity;

namespace WorldBank.Microservices.IamMicroservice.STS.Identity.Configuration.Interfaces
{
    public interface IRootConfiguration
    {
        AdminConfiguration AdminConfiguration { get; }

        RegisterConfiguration RegisterConfiguration { get; }
    }
}





