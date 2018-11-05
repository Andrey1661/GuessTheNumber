using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuessTheNumber.Models
{
    public struct GameModel
    {
        public string HiddenNumber { get; set; }
        public string Mask { get; set; }
        public int AttemptsCount { get; set; }
        public bool Success { get; set; }
    }
}