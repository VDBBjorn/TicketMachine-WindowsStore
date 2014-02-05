using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using TicketMachine.Domain.PCL.Domain;
using TicketMachine.Infrastructure;
using TicketMachine.Lib.Domain;

namespace TicketMachine.Controllers
{
    [Authorize]
    public class ShoppingListController : ApiController
    {
        private ICustomerRepository customerRepository;
        private IStoreRepository storeRepository;

        public ShoppingListController(ICustomerRepository customerRepository, IStoreRepository storeRepository)
        {
            this.customerRepository = customerRepository;
            this.storeRepository = storeRepository;
        }

        //api/v1/customer/?productPackingId=xx 
        public ProductPacking GetProdcutPackingToShoppingList([ModelBinder(typeof(CustomerModelBinder))]Customer customer, decimal productPackingId)
        {
            ProductPacking productPacking = storeRepository.GetProdcutPakcing(productPackingId);
            if (productPacking != null)
            {
                //customer.ShoppingList.AddProductPakcingToShoppingList(productPacking);
                customerRepository.FindBy(customer.CustomerId).AddProductPakcingToShoppingList(productPacking);
                customerRepository.SaveChanges();
            }
            return productPacking;
            //throw new HttpResponseException(HttpStatusCode.NotFound);
        }

        //api/v1/customer/?removeProductPackingId=xx 
        public bool GetRemoveProdcutPackingFromShoppingList([ModelBinder(typeof(CustomerModelBinder))]Customer customer, decimal removeProductPackingId)
        {
            ProductPacking prodcutPackingToRemove = customer.ShoppingList.ProductPackings.FirstOrDefault(pp => pp.PackingId == removeProductPackingId);
            customer.RemoveProductPakcingFromShoppingList(prodcutPackingToRemove);
            Customer customerFromRepos = customerRepository.FindBy(customer.CustomerId);
            customerFromRepos.RemoveProductPakcingFromShoppingList(prodcutPackingToRemove);
            customerRepository.RemoveProductPackingFromShoppingList(customerFromRepos, prodcutPackingToRemove);
            customerRepository.SaveChanges();
            return true;
        }

        //api/v1/shoppinglist/ 
        public HttpResponseMessage Post([ModelBinder(typeof(CustomerModelBinder))]Customer customer, decimal productPackingId)
        {
            ProductPacking productPacking = storeRepository.GetProdcutPakcing(productPackingId);
            if (productPacking != null)
            {
                //customer.ShoppingList.AddProductPakcingToShoppingList(productPacking);
                customerRepository.FindBy(customer.CustomerId).AddProductPakcingToShoppingList(productPacking);
                customerRepository.SaveChanges();
            }
            //return voucher;
            //return Request.CreateResponse(HttpStatusCode.Accepted);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, productPacking);
            //response.Headers.Location = new Uri(Url.Link("DefaultApi", new { Id = p.Id }));
            return response;

        }

        //api/v1/shoppinglist/ 
        public void Delete([ModelBinder(typeof(CustomerModelBinder))]Customer customer, decimal removeProductPackingId)
        {
            ProductPacking prodcutPackingToRemove = customer.ShoppingList.ProductPackings.FirstOrDefault(pp => pp.PackingId == removeProductPackingId);
            if (prodcutPackingToRemove != null)
            {
                customer.RemoveProductPakcingFromShoppingList(prodcutPackingToRemove);
                Customer customerFromRepos = customerRepository.FindBy(customer.CustomerId);
                customerFromRepos.RemoveProductPakcingFromShoppingList(prodcutPackingToRemove);
                customerRepository.RemoveProductPackingFromShoppingList(customerFromRepos, prodcutPackingToRemove);
                customerRepository.SaveChanges();
            }
        }


    }
}
