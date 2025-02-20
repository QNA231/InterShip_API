﻿using System.ComponentModel.DataAnnotations.Schema;

namespace InternShip_API.Entities
{
    [Table("RankCustomer_tbl")]
    public class RankCustomer
    {
        public int Id { get; set; }
        public int Point { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public IEnumerable<User>? Users { get; set; }
        public IEnumerable<Promotion>? Promotions { get; set; }
    }
}
