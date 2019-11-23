using System.ComponentModel.DataAnnotations;

namespace WestPay.Access.DAL.Entities.Terminals
{
    // Its kindof logical terminal (TerminalIds) ** Need better naming :(
    public class OperationSetting 
    {
        [Required]
        public int Id { get; set; }

        [Required, StringLength(40)]
        public string PhysicalTerminalId { get; set; }

        [Required]
        public string TerminalModelId { get; set; }

        [Required]
        public string TerminalOperationModeId { get; set; }

        // public int WestidId { get; set; } //Need qualified name

        public int TerminalidOrderId { get; set; }

        [StringLength(100)]
        public string ReceiptMerchantName { get; set; }

        [StringLength(30)]
        public string ReceiptPhoneNumber { get; set; }

        public bool Signature { get; set; }

        public bool Tipping { get; set; }

        public bool ChipXpress { get; set; }

        public int LastEvent { get; set; }
    }
}
