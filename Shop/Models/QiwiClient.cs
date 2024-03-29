﻿using Qiwi.BillPayments.Client;
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
        private static string _secertToken = "";
        private static string _publicKey = "";

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
