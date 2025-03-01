﻿using System;

namespace MicroRabbit.Banking.Application.Models
{
    public class TransferLogViewModel
    {
        public int Id { get; set; }
        public int FromAccount { get; set; }
        public int ToAccount { get; set; }
        public decimal TransferAmount { get; set; }
        public DateTime TimeStamps { get; set; }
    }
}