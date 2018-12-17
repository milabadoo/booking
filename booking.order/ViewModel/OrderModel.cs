﻿using booking.order.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace booking.client.ViewModel
{
    public class OrderModel
    {
        public string FlightId { get; set; }
        public string ClientId { get; set; }
        public decimal Summ { get; set; }
        public OrderStatus Status { get; set; }
    }
}
