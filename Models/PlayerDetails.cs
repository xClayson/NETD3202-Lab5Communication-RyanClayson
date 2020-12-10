using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace NETD3202_Lab5Communication_RyanClayson.Models
{
    public class PlayerDetails
    {
        [Key]
        public int playerID { get; set; } //priamry key of table
        public int playerAge { get; set; } // Age of Player
        public string playerHeight { get; set; }// Height of Player
        public int playerWeight { get; set; } // Weight of Player 
    }
}
