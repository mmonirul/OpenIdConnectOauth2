using System.ComponentModel.DataAnnotations;

namespace WestPay.Access.DAL.Entities.Terminals
{
    public class TerminalOperationMode
    {
        public int Id { get; set; }

        [StringLength(30)]
        public string Name { get; set; }

        public string RawName { get; set; }
    }
}
