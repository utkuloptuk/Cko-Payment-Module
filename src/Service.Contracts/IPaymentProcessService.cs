using Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IPaymentProcessService
    {
        InvoiceDto CreatePayment(PaymentProcessDto paymentProcessDto);
    }
}
