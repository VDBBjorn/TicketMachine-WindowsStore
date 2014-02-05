using System;
using System.Text;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.ModelBinding;
using System.Web.Http.ValueProviders;
using TicketMachine.Domain.PCL.Domain;
using TicketMachine.Lib.Domain;

namespace TicketMachine.Infrastructure
{
    public class CustomerModelBinder : IModelBinder
    {
        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            if (bindingContext.ModelType != typeof(Customer))
            {
                return false;
            }
            var encoding = Encoding.GetEncoding("iso-8859-1");
            var credentials = encoding.GetString(Convert.FromBase64String(actionContext.ControllerContext.Request.Headers.Authorization.Parameter));
            int separator = credentials.IndexOf(':');
            decimal customerId = Convert.ToDecimal(credentials.Substring(0, separator));
            string password = credentials.Substring(separator + 1);
            
            ICustomerRepository customerRepository = GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(ICustomerRepository)) as ICustomerRepository;
            bindingContext.Model = customerRepository.FindBy(customerId); 
            
            return true;
        }
    }
}

