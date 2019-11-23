using System;

namespace WestPay.Access.DAL.Entities.Terminals
{
    public class PhysicalTerminal
    {
        public int Id { get; set; }
        public int LastEvent { get; set; }
        public DateTime? TimeCreated { get; set; }
        public DateTime? TimeModified { get; set; }
        public string Serial { get; set; }

        public int TerminalModelId { get; set; }
        public TerminalModel TerminalModel { get; set; }

        public int CustomerId { get; set; }

        public string TerminalId { get; set; }
        public string MerchantPassword { get; set; }

        public int TerminalOperationSettingId { get; set; }
    }
}
