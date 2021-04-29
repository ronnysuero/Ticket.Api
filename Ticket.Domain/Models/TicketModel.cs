using System;

namespace Ticket.Domain.Models
{
    public class TicketModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool Status { get; set; }
    }
}
