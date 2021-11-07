using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
namespace payme.Core.DTOs.APIRequests
{
    public class SubAccountReq
    {
        [JsonProperty("business_name")]
        public string BusinessName { get; set; }

        [JsonProperty("settlement_bank")]
        public string SettlementBank { get; set; }

        [JsonProperty("account_number")]
        public string AccountNumber { get; set; }

        [JsonProperty("percentage_charge")]
        public long PercentageCharge { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}