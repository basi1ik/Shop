using Qiwi.BillPayments.Client;
using Qiwi.BillPayments.Model;
using Qiwi.BillPayments.Model.In;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public static class QiwiClient
    {
        private static string _secertToken = "eyJ2ZXJzaW9uIjoiUDJQIiwiZGF0YSI6eyJwYXlpbl9tZXJjaGFudF9zaXRlX3VpZCI6IjNxeGVxcS0wMCIsInVzZXJfaWQiOiI3OTUxNjIwNjA2OCIsInNlY3JldCI6Ijk0ZGVjYzA4Mzk2YjEyZDQ5ZGIyMTE1ODAzOGU0Y2U2YTQ2YzIxZjVmNDBhOGZhYTFhZjEyMGVmMTFmNGY4NjIifX0=";
        private static string _publicKey = "48e7qUxn9T7RyYE1MVZswX1FRSbE6iyCj2gCRwwF3Dnh5XrasNTx3BGPiMsyXQFNKQhvukniQG8RTVhYm3iP4xpmMTfqsECTjqv45mDUoqbfK9ZDiCJDQf4Ua88dJTHt152zncDCWe3Nd64sAmXTQj1xwqD6avZebMrd2GPdRTS3AjJ1ZzDs4p9Msg3gX";

        public static Uri Run(decimal total ) {

            var client = BillPaymentsClientFactory.Create(secretKey: _secertToken);
                        
            var amount = new MoneyAmount {
                ValueDecimal = total,
                CurrencyEnum = CurrencyEnum.Rub
            };
            var billId = Guid.NewGuid().ToString();

            var successUrl = "https://github.com/basi1ik/basi1ik.github.io";         

            var paymentInfo = new PaymentInfo() {
                PublicKey = _publicKey,
                Amount = amount,
                BillId = billId,
                SuccessUrl = new Uri(successUrl)
            };            

            var paymentUrl = client.CreatePaymentForm(paymentInfo);
                      
            return paymentUrl;       
        }

    }
}
