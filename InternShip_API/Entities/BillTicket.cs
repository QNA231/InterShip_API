using System.ComponentModel.DataAnnotations.Schema;

namespace InternShip_API.Entities
{
    [Table("BillTicket_tbl")]
    public class BillTicket
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int BillId { get; set; }
        public int TicketId { get; set; }
        public Bill Bill { get; set; }
        public Ticket Ticket { get; set; }
    }
}
