using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRadar.Models
{
    public class Car
    {
        public int      Id      { get; set; }

        [Required]
        public string   Brand   { get; set; }

        [Required]
        public string   Model   { get; set; }

        [Display(Name = "Price in DKK")]
        public int      Price   { get; set; }

        [Required]
        public int      Year    { get; set; }
        public string   Image   { get; set; }

        [Required]
        public string   Link    { get; set; }
    }
}