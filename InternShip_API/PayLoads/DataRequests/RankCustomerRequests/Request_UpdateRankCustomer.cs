﻿using InternShip_API.Entities;

namespace InternShip_API.PayLoads.DataRequests.RankCustomerRequests
{
    public class Request_UpdateRankCustomer
    {
        public int Id { get; set; }
        public int Point { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
    }
}