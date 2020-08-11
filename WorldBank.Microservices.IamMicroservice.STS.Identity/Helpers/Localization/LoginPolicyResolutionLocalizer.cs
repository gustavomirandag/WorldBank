﻿using WorldBank.Microservices.IamMicroservice.Shared.Configuration.Identity;
using WorldBank.Microservices.IamMicroservice.STS.Identity.Configuration;

namespace WorldBank.Microservices.IamMicroservice.STS.Identity.Helpers.Localization
{
    public static class LoginPolicyResolutionLocalizer
    {
        public static string GetUserNameLocalizationKey(LoginResolutionPolicy policy)
        {
            switch (policy)
            {
                case LoginResolutionPolicy.Username:
                    return "Username";
                case LoginResolutionPolicy.Email:
                    return "Email";
                default:
                    return "Username";
            }
        }
    }
}






