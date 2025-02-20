﻿using System.ComponentModel.DataAnnotations.Schema;

namespace InternShip_API.Entities
{
    [Table("Seat_tbl")]
    public class Seat
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int SeatStatusId { get; set; }
        public string Line { get; set; }
        public int RoomId { get; set; }
        public bool IsActive { get; set; }
        public int SeatTypeId { get; set; }
        public SeatStatus SeatStatus  { get; set; }
        public SeatType SeatType { get; set; }
        public Room Room { get; set; }
        public IEnumerable<Ticket>? Tickets { get; set; }
    }
}
