using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace payme.Core.DTOs.APIRequests
{
    public class ProductReq
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("price")]
        public long Price { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("limited")]
        public bool Limited { get; set; }

        [JsonProperty("quantity")]
        public long Quantity { get; set; }
    }
}
