using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FileUploadExample.Models
{
    public class Food
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        /// <summary>
        /// The location where the photo is stored
        /// </summary>
        public string PhotoUrl { get; set; }

        /// <summary>
        /// The photo file upload
        /// </summary>
        [NotMapped] //Tell Entity Framework to ignore property
        public IFormFile Photo { get; set; }
    }
}
