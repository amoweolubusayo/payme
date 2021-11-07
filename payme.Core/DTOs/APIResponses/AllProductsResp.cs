using System;

namespace payme.Core.DTOs.APIResponses
{
    public class AllProductsResp
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public Datum[] Data { get; set; }
        public Meta Meta { get; set; }
    }
     public partial class Datum
    {
        public long Integration { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ProductCode { get; set; }
        public long Price { get; set; }
        public string Currency { get; set; }
        public long Quantity { get; set; }
        public object QuantitySold { get; set; }
        public string Type { get; set; }
        public string ImagePath { get; set; }
        public string FilePath { get; set; }
        public bool IsShippable { get; set; }
        public bool Unlimited { get; set; }
        public string Domain { get; set; }
        public bool Active { get; set; }
        public object Features { get; set; }
        public bool InStock { get; set; }
        public object Metadata { get; set; }
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public partial class Meta
    {
        public long Total { get; set; }
        public long Skipped { get; set; }
        public long PerPage { get; set; }
        public long Page { get; set; }
        public long PageCount { get; set; }
    }
}