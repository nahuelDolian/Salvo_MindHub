﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoSalvo.Models
{
    public class Score
    {
        public long Id { get; set; }
        public long GameId { get; set; }
        public long PlayerId { get; set; }
        public double Point { get; set; }
        public Player Player { get; set; }
        public Game Game { get; set; }
        public DateTime? FinishDate { get; set; }

    }
}
