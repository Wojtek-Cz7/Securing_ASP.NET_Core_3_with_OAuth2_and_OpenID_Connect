// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace Wojtek.IDP
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            { 
                new IdentityResources.OpenId(),  //open_id scope - ensures, that userId can be requested
                new IdentityResources.Profile()  // scope for profile-related claims
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            { };

        public static IEnumerable<Client> Clients =>
            new Client[]
            { new Client
                {
                    ClientName = "Image Gallery",
                    ClientId = "image_gallery_client",
                    AllowedGrantTypes = new List<string> { GrantType.AuthorizationCode },
                    RedirectUris = new List<string> { "https://localhost:44389/signin-oidc" },
                    AllowedScopes = { IdentityServerConstants.StandardScopes.OpenId, IdentityServerConstants.StandardScopes.Profile },
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    PostLogoutRedirectUris = new List<string> { "https://localhost:44389/signout-callback-oidc" },
                    RequirePkce = true,
                }
            };
    }
}