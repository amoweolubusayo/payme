using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace payme.Core.DTOs.APIRequests
{
    public class RecurringTransactionReq
    {

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("amount")]
        public long Amount { get; set; }
        [JsonProperty("plan")]
        public string Plan { get; set; }
        [JsonProperty("subaccount")]
        public string Subaccount { get; set; }

        [JsonProperty("bearer")]
        public string Bearer { get; set; }
    }
}