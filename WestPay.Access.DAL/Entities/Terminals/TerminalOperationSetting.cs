using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WestPay.Access.DAL.Entities.Terminals
{

    public class TerminalOperationSetting
    {
        public Guid Id { get; set; }

        public int TerminalidId { get; set; }

        public int TerminalId { get; set; }

        public int TerminalOperatingModeId { get; set; }

        public bool IsActive { get; set; }

        public DateTime? FirstTransactionTime { get; set; }

        public DateTime? LastTransactionTime { get; set; }

        [StringLength(20)]
        public string PAVersion { get; set; }

        [StringLength(220)]
        public string ReceivedParameters { get; set; }
    }
}
