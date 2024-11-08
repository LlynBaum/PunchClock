﻿using System.ComponentModel.DataAnnotations;

namespace M223PunchclockDotnet.Model
{
    public class Entry
    {
        public int Id { get; set; }

        [Required] 
        public DateTime CheckIn { get; set; }

        [Required] 
        public DateTime CheckOut { get; set; }

        public Category? Category { get; set; }

        public List<Tag> Tags { get; set; } = [];
        
        [Required]
        public int UserId { get; set; }

        public User User { get; set; } = null!;
    }
}