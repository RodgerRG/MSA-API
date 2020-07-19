using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MSA_API.Models
{
    public class Address
    {
        [Required]
        public int studentId { get; set; }
        [Required]
        public int streetNumber { get; set; }
        [Required]
        public string street { get; set; }
        public string suburb { get; set; }
        [Required]
        public string city { get; set; }
        [Required]
        public int postCode { get; set; }
        [Required]
        public string country { get; set; }
    }
}
