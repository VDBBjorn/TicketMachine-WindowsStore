using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using TicketMachine.Domain.PCL.Domain;
using TicketMachine.Infrastructure;
using TicketMachine.Lib.Domain;
using TicketMachine.Lib.Models;

namespace TicketMachine.Controllers
{
    [Authorize]
    public class CustomerController : ApiController
    {
        private ICustomerRepository customerRepository;
     
        public CustomerController(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public Customer GetCustomer([ModelBinder(typeof(CustomerModelBinder))]Customer customer, Address address)
        {
            if (customer != null)
                return customer;
            throw new HttpResponseException(HttpStatusCode.NotFound);
        }

        public HttpResponseMessage PutAddress([ModelBinder(typeof(CustomerModelBinder))]Customer customer, Address address)
        {
            Address addressRepos = customerRepository.FindBy(customer.CustomerId).Address; 
            try
            {
                addressRepos.Street = address.Street;
                addressRepos.HouseNumber = address.HouseNumber;
                addressRepos.PostalCode = address.PostalCode;
                addressRepos.City = address.City;
                addressRepos.Country = address.Country; 

                customerRepository.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                var err = new HttpError(ex.Message);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, err);
            }
        }
    }

}
