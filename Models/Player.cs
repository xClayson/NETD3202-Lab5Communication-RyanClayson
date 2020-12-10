using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace NETD3202_Lab5Communication_RyanClayson.Models
{
    public class Player
    {
        [Key]
        public int playerID { get; set; } // ID of Player, Primary Key
        public string firstName { get; set; } // First Name of Player
        public string lastName { get; set; }// Last Name of Player
        public int yearDrafted { get; set; } // Year Drafted into the league
        public string teamName { get; set; } // Team playing for
    }
}
