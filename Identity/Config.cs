// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace Identity
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
            new ApiResource("ResourcePortfolio")
            {
                Scopes = {
                    "PortfolioReadPermission","PortfolioWriteCommentPermission","PortfolioWriteMessagePermission"
                    // kullanıcının siteyi Görüntüleme, yorum yazma, mesaj yazma yetkileri var.
                }
            },
            new ApiResource("ResourcePortfolioAdmin")
            {
                Scopes =
                {
                    "PortfolioFullPermission","PortfolioReadPermission","PortfolioWriteCommentPermission","PortfolioWriteMessagePermission"
                }
            },
            new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
        };

        // Token içerinde tutulacak bilgiler
        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Email(),
            new IdentityResources.Profile(),
        };

        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
        {
            new ApiScope("PortfolioReadPermission","Displaying portfolio authority for normal user"),  // bu yetkiye sahip kişilerde gözükecek yazı
            new ApiScope("PortfolioWriteCommentPermission","Writing Blog Comment authority for normal user"),
            new ApiScope("PortfolioWriteMessagePermission","Writing Messages authority for normal user"),
            new ApiScope("PortfolioFullPermission","Full authority for Admin"),
            new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
        };

        public static IEnumerable<Client> Clients => new Client[]
        {
            // visitor | Bir giriş yapma işlemi gerektirmeyecek
            new Client
            {
                ClientId = "PortfolioVisitorId",
                ClientName = "VisitorClient",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = {new Secret("PortfolioSecret".Sha256())},
                AllowedScopes = { "PortfolioReadPermission", "PortfolioWriteCommentPermission", "PortfolioWriteMessagePermission", "PortfolioFullPermission" }
            },

            // Admin | Tüm Yetkiler Login gerekecek register kalıdırılacak
            new Client
            {
                ClientId = "PortfolioAdminId",
                ClientName = "AdminClient",
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                ClientSecrets = {new Secret("PortfolioSecret".Sha256())},
                AllowedScopes = { "PortfolioFullPermission", "PortfolioReadPermission", "PortfolioWriteCommentPermission", "PortfolioWriteMessagePermission",
                IdentityServerConstants.LocalApi.ScopeName,
                IdentityServerConstants.StandardScopes.Email,
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile,
                },
                AccessTokenLifetime = 3600
            }
        };

        #region
        //public static IEnumerable<IdentityResource> IdentityResources =>
        //           new IdentityResource[]
        //           {
        //        new IdentityResources.OpenId(),
        //        new IdentityResources.Profile(),
        //           };

        //public static IEnumerable<ApiScope> ApiScopes =>
        //    new ApiScope[]
        //    {
        //        new ApiScope("scope1"),
        //        new ApiScope("scope2"),
        //    };

        //public static IEnumerable<Client> Clients =>
        //    new Client[]
        //    {
        //        // m2m client credentials flow client
        //        new Client
        //        {
        //            ClientId = "m2m.client",
        //            ClientName = "Client Credentials Client",

        //            AllowedGrantTypes = GrantTypes.ClientCredentials,
        //            ClientSecrets = { new Secret("511536EF-F270-4058-80CA-1C89C192F69A".Sha256()) },

        //            AllowedScopes = { "scope1" }
        //        },

        //        // interactive client using code flow + pkce
        //        new Client
        //        {
        //            ClientId = "interactive",
        //            ClientSecrets = { new Secret("49C1A7E1-0C79-4A89-A3D6-A37998FB86B0".Sha256()) },

        //            AllowedGrantTypes = GrantTypes.Code,

        //            RedirectUris = { "https://localhost:44300/signin-oidc" },
        //            FrontChannelLogoutUri = "https://localhost:44300/signout-oidc",
        //            PostLogoutRedirectUris = { "https://localhost:44300/signout-callback-oidc" },

        //            AllowOfflineAccess = true,
        //            AllowedScopes = { "openid", "profile", "scope2" }
        //        },
        //    };
        #endregion
    }
}