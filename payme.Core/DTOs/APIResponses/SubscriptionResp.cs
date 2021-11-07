using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace payme.Core.DTOs.APIResponses
{
    public class SubscriptionResp
    {
        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public SubscriptionData Data { get; set; }
    }
    public class SubscriptionData
    {
        [JsonProperty("customer")]
        public long Customer { get; set; }

        [JsonProperty("plan")]
        public long Plan { get; set; }

        [JsonProperty("integration")]
        public long Integration { get; set; }

        [JsonProperty("domain")]
        public string Domain { get; set; }

        [JsonProperty("start")]
        public long Start { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("quantity")]
        public long Quantity { get; set; }

        [JsonProperty("amount")]
        public long Amount { get; set; }

        [JsonProperty("authorization")]
        public Authorization Authorization { get; set; }

        [JsonProperty("subscription_code")]
        public string SubscriptionCode { get; set; }

        [JsonProperty("email_token")]
        public string EmailToken { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTime UpdatedAt { get; set; }
    }
    public partial class Authorization
    {
      [JsonProperty("authorization_code")]
        public string AuthorizationCode { get; set; }

        [JsonProperty("bin")]
        public long Bin { get; set; }

        [JsonProperty("last4")]
        public long Last4 { get; set; }

        [JsonProperty("exp_month")]
        public long ExpMonth { get; set; }

        [JsonProperty("exp_year")]
        public long ExpYear { get; set; }

        [JsonProperty("channel")]
        public string Channel { get; set; }

        [JsonProperty("card_type")]
        public string CardType { get; set; }

        [JsonProperty("bank")]
        public string Bank { get; set; }

        [JsonProperty("country_code")]
        public string CountryCode { get; set; }

        [JsonProperty("brand")]
        public string Brand { get; set; }

        [JsonProperty("reusable")]
        public bool Reusable { get; set; }

        [JsonProperty("signature")]
        public string Signature { get; set; }

        [JsonProperty("account_name")]
        public string AccountName { get; set; }
    }
}