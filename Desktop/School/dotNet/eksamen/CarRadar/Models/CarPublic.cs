using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRadar.Models
{
    public class CarPublic
    {
        public int      Id      { get; set; }
        public string   Brand   { get; set; }
        public string   Model   { get; set; }
        public int      Price   { get; set; }
        public int      Year    { get; set; }
    }
}