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
    public class VoucherController : ApiController
    {
        private ICustomerRepository customerRepository;

        public VoucherController(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        //api/v1/voucher/?voucherBarcode=xx 
        public Voucher GetVoucherToCustomer([ModelBinder(typeof(CustomerModelBinder))]Customer customer, string voucherBarcode)
        {
            Voucher voucher = customerRepository.FindVoucherByBarcode(voucherBarcode);
            if (voucher != null)
            {
                //customer.AddVoucher(voucher);
                customerRepository.FindBy(customer.CustomerId).AddVoucher(voucher);
                customerRepository.SaveChanges();
            }
            return voucher;
            //throw new HttpResponseException(HttpStatusCode.NotFound);
        }

        //api/v1/voucher/ 
        public HttpResponseMessage PutVoucher([ModelBinder(typeof(CustomerModelBinder))]Customer customer, string barcode)
        {
            Voucher voucher = customerRepository.FindVoucherByBarcode(barcode);
            try
            {
                if (voucher != null)
                {
                    customerRepository.FindBy(customer.CustomerId).AddVoucher(voucher);
                    customerRepository.SaveChanges();
                }
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, voucher);
                return response;
            }
            catch (Exception ex)
            {
                var err = new HttpError(ex.Message);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, err);
            }
        }
    }

}
