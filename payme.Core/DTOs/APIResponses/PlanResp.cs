using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
namespace payme.Core.DTOs.APIResponses
{
    public class PlanResp
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public PlanData Data { get; set; }
    }

    public class PlanData
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("amount")]
        public long Amount { get; set; }

        [JsonProperty("interval")]
        public string Interval { get; set; }

        [JsonProperty("integration")]
        public long Integration { get; set; }

        [JsonProperty("domain")]
        public string Domain { get; set; }

        [JsonProperty("plan_code")]
        public string PlanCode { get; set; }

        [JsonProperty("send_invoices")]
        public bool SendInvoices { get; set; }

        [JsonProperty("send_sms")]
        public bool SendSms { get; set; }

        [JsonProperty("hosted_page")]
        public bool HostedPage { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTime UpdatedAt { get; set; }
    }
    
}