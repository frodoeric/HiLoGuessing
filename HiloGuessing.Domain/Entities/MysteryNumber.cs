﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiLoGuessing.Infrastructure
{
    public class MysteryNumber
    {
        [Key]
        public int Id { get; set; }
        public int GeneratedMysteryNumber { get; set; }
        public int NumberOfAttempts { get; set; } = 1;

        public List<Attempt> Attempts { get; set; } = new();
    }

    public class Attempt
    {
        [Key]
        public int Id { get; set; }
        public int AttemptedNumber { get; set; }

        public int MysteryNumberId { get; set; }
        public MysteryNumber MysteryNumber { get; set; }
    }

}
