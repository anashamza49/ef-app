﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace efApp.Models
{
    public class Subject
    {
        [Key]
        public int Id { get; set; }
        [Required, MinLength(5)]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
