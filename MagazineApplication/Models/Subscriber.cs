using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MagazineApplication.Models
{
    public class Subscriber
    {
        public int Id { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Email { get; set; }

        public string Phone { get; set; }

       
        public int SubscriberDetailId { get; set; }

        [ForeignKey("SubscriberDetailId")]
        public virtual SubscriberDetail SubscriberDetails { get; set; }
    }
}