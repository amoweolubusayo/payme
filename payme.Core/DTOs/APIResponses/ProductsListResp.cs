using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace payme.Core.DTOs.APIResponses
{
    public class ProductsListResp
    {
        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public ProductDatum[] Data { get; set; }

        [JsonProperty("meta")]
        public ProductMeta Meta { get; set; }
    }

    public class ProductDatum
    {
        [JsonProperty("integration")]
        public long Integration { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("product_code")]
        public string ProductCode { get; set; }

        [JsonProperty("price")]
        public long Price { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("quantity")]
        public long Quantity { get; set; }

        [JsonProperty("quantity_sold")]
        public object QuantitySold { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("image_path")]
        public string ImagePath { get; set; }

        [JsonProperty("file_path")]
        public string FilePath { get; set; }

        [JsonProperty("is_shippable")]
        public bool IsShippable { get; set; }

        [JsonProperty("unlimited")]
        public bool Unlimited { get; set; }

        [JsonProperty("domain")]
        public string Domain { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("features")]
        public object Features { get; set; }

        [JsonProperty("in_stock")]
        public bool InStock { get; set; }

        [JsonProperty("metadata")]
        public object Metadata { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTimeOffset UpdatedAt { get; set; }
    }

    public class ProductMeta
    {
        [JsonProperty("total")]
        public long Total { get; set; }

        [JsonProperty("skipped")]
        public long Skipped { get; set; }

        [JsonProperty("perPage")]
        public long PerPage { get; set; }

        [JsonProperty("page")]
        public long Page { get; set; }

        [JsonProperty("pageCount")]
        public long PageCount { get; set; }
    }
}

