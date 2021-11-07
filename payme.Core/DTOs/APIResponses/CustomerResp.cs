using System;

namespace payme.Core.DTOs.APIResponses
{
    public class CustomerResp
    {

        public bool Status { get; set; }

        public string Message { get; set; }

        public CustomerData Data { get; set; }

        public CustomerResp()
        {
        }
    }
    public class CustomerData
    {
        public string Email { get; set; }
        public long Integration { get; set; }
        public string Domain { get; set; }
        public string CustomerCode { get; set; }
        public long Id { get; set; }
        public bool Identified { get; set; }
        public object Identifications { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

}