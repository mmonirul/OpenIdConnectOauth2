namespace WestPay.Access.DAL.Entities.Terminals
{
    public class TerminalModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SerialPrefix { get; set; }
        public bool? IsTerminal { get; set; }
    }
}
