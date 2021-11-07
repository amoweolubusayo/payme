using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace payme.Core.DTOs.APIResponses
{
    public class ProductResp
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public ProductData Data { get; set; }
    }
    public class ProductData
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Currency { get; set; }
        public long Price { get; set; }
        public bool Unlimited { get; set; }
        public string Domain { get; set; }
        public long Integration { get; set; }
        public string ProductCode { get; set; }
        public long Quantity { get; set; }
        public string Type { get; set; }
        public bool IsShippable { get; set; }
        public bool Active { get; set; }
        public bool InStock { get; set; }
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
