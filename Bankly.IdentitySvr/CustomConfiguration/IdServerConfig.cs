using System;
using System.Collections.Generic;
using IdentityServer4;
using IdentityServer4.Models;

namespace Bankly.IdentitySvr.CustomConfiguration
{
    public static class IdServerConfig
    {
        public static IEnumerable<ApiResource> GetAllApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("complianceapi")
                {
                    Scopes = { "complianceapi" }
                }

            };
        }

        public static IEnumerable<ApiScope> ApiScopes =>
           new ApiScope[]
           {
                new ApiScope("complianceapi"),
                
           };

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "compliance",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets =
                    {
                        new Secret("A53j98983nbf8hf83fjjf0383983".Sha256())
                    },
                    AllowedScopes = { "complianceapi" },
                    RequireConsent =false
                    

                },

                 new Client
                {
                    ClientId = "ro.compliance",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    ClientSecrets =
                    {
                        new Secret("8783784878498jjhjhdjhjh8783pj".Sha256())
                    },
                    AllowedScopes = { "complianceapi" , "openid", "profile"},
                    RequireConsent =false

                },

                 new Client
                {
                    ClientId = "ro.complianceapi",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    ClientSecrets =
                    {
                        new Secret("8783784878498jjhjhdjhjh8783pj".Sha256())
                    },
                    AllowedScopes = {
                         IdentityServerConstants.StandardScopes.OpenId,
                         IdentityServerConstants.StandardScopes.Profile,
                     },
                    RequireConsent =false

                }
            };
        }
    }
}
