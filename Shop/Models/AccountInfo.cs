using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class AccountInfo
    {
        [JsonProperty("account")]
        public string Account { get; set; }
        [JsonProperty("balance")]
        public decimal Balance { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("account_type")]
        public string AccountType { get; set; }
        [JsonProperty("identified")]
        public bool Identified { get; set; }
        [JsonProperty("account_status")]
        public string AccountStatus { get; set; }
        [JsonProperty("balance_details")]
        public BalanceDetails BalanceDetils { get; set; }
    }

    public class BalanceDetails
    {
        [JsonProperty("total")]
        public decimal Total { get; set; }
        [JsonProperty("available")]
        public decimal Available { get; set; }
    }
}
