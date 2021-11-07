using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace payme.Core.DTOs.APIRequests
{
    public class PlanReq
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("interval")]
        public string Interval { get; set; }

        [JsonProperty("amount")]
        public long Amount { get; set; }
    }
}