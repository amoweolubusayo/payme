using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
namespace payme.Core.DTOs.APIRequests
{
    public class SubscriptionReq
    {
        [JsonProperty("customer")]
        public string Customer { get; set; }

        [JsonProperty("plan")]
        public string Plan { get; set; }

        [JsonProperty("authorization")]
        public string Authorization { get; set; }
    }
}