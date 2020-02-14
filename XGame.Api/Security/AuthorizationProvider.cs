using Microsoft.Owin.Security.OAuth;
using Microsoft.Practices.Unity;
using Newtonsoft.Json;
using System;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using XGame.Domain.Arguments.Player;
using XGame.Domain.Interfaces.Services;


namespace XGame.Api.Security
{
    public class AuthorizationProvider : OAuthAuthorizationServerProvider
    {
        private readonly UnityContainer _container;

        public AuthorizationProvider(UnityContainer container)
        {
            _container = container;
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            try
            {
                IServicePlayer servicePlayer = _container.Resolve<IServicePlayer>();


                PlayerAuthenticationRequest request = new PlayerAuthenticationRequest();
                request.Email = context.UserName;
                request.Password = context.Password;

                PlayerAuthenticationResponse response = servicePlayer.PlayerAuthentication(request);



                if (servicePlayer.IsInvalid())
                {
                    if (response == null)
                    {
                        context.SetError("invalid_grant", "Invalid Email!");
                        return;
                    }
                }

                servicePlayer.ClearNotifications();

                if (response == null)
                {
                    context.SetError("invalid_grant", "Player Not Found");
                    return;
                }

                var identity = new ClaimsIdentity(context.Options.AuthenticationType);

                //Definindo as Claims
                identity.AddClaim(new Claim("Player", JsonConvert.SerializeObject(response)));

                var principal = new GenericPrincipal(identity, new string[] { });

                Thread.CurrentPrincipal = principal;

                context.Validated(identity);
            }
            catch (Exception ex)
            {
                context.SetError("invalid_grant", ex.Message);
                return;
            }
        }
    }
}