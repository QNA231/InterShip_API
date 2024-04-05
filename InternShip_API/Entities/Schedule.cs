﻿using System.ComponentModel.DataAnnotations.Schema;

namespace InternShip_API.Entities
{
    [Table("Schedule_tbl")]
    public class Schedule
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }
        public string Code { get; set; }
        public int MovieId { get; set; }
        public string Name { get; set; }
        public int RoomId { get; set; }
        public bool IsActive { get; set; } 
        public Room Room { get; set; }
        public Movie Movie { get; set; }
        public IEnumerable<Ticket>? Tickets { get; set; }
    }
}
