using System;

namespace payme.Core.DTOs.APIResponses
{
    public class SubAccountResp
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public SubAccountData Data { get; set; }
    }
    public class SubAccountData
    {
        public long Integration { get; set; }
        public string Domain { get; set; }
        public string SubaccountCode { get; set; }
        public string BusinessName { get; set; }
        public object Description { get; set; }
        public object PrimaryContactName { get; set; }
        public object PrimaryContactEmail { get; set; }
        public object PrimaryContactPhone { get; set; }
        public object Metadata { get; set; }
        public double PercentageCharge { get; set; }
        public bool IsVerified { get; set; }
        public string SettlementBank { get; set; }
        public string AccountNumber { get; set; }
        public string SettlementSchedule { get; set; }
        public bool Active { get; set; }
        public bool Migrate { get; set; }
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}