using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http;
using TicketMachine.Lib.Domain;

namespace TicketMachine.Modules
{
    public class BasicAuthHttpModule : IHttpModule
        {
            private const string Realm = "My Realm";

            public void Init(HttpApplication context)
            {
                // Register event handlers
                context.AuthenticateRequest += OnApplicationAuthenticateRequest;
                context.EndRequest += OnApplicationEndRequest;
            }

            private static void SetPrincipal(IPrincipal principal)
            {
                Thread.CurrentPrincipal = principal;
                if (HttpContext.Current != null)
                {
                    HttpContext.Current.User = principal;
                }
            }

            private static bool CheckPassword(decimal customerId, string password)
            {
                ICustomerRepository customerRepository = GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(ICustomerRepository)) as ICustomerRepository;
                return customerRepository.CheckPassword(customerId, password);
            }

            private static bool AuthenticateUser(string credentials)
            {
                bool validated = false;
                try
                {
                    var encoding = Encoding.GetEncoding("iso-8859-1");
                    credentials = encoding.GetString(Convert.FromBase64String(credentials));

                    int separator = credentials.IndexOf(':');
                    string customerId = credentials.Substring(0, separator);
                    string password = credentials.Substring(separator + 1);

                    validated = CheckPassword(Convert.ToDecimal(customerId), password);
                    if (validated)
                    {
                        var identity = new GenericIdentity(customerId);
                        SetPrincipal(new GenericPrincipal(identity, null));
                    }
                }
                catch (FormatException)
                {
                    // Credentials were not formatted correctly.
                    validated = false;

                }
                return validated;
            }

            private static void OnApplicationAuthenticateRequest(object sender, EventArgs e)
            {
                var request = HttpContext.Current.Request;
                var authHeader = request.Headers["Authorization"];
                if (authHeader != null)
                {
                    var authHeaderVal = AuthenticationHeaderValue.Parse(authHeader);

                    // RFC 2617 sec 1.2, "scheme" name is case-insensitive
                    if (authHeaderVal.Scheme.Equals("basic",
                            StringComparison.OrdinalIgnoreCase) &&
                        authHeaderVal.Parameter != null)
                    {
                        AuthenticateUser(authHeaderVal.Parameter);
                    }
                }
            }

            // If the request was unauthorized, add the WWW-Authenticate header 
            // to the response.
            private static void OnApplicationEndRequest(object sender, EventArgs e)
            {
                var response = HttpContext.Current.Response;
                if (response.StatusCode == 401)
                {
                    response.Headers.Add("WWW-Authenticate",
                        string.Format("Basic realm=\"{0}\"", Realm));
                }
            }

            public void Dispose()
            {
            }
        }
    }
