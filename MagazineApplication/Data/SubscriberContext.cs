using MagazineApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MagazineApplication.Models
{
    public class SubscriberContext : DbContext

    {
        public SubscriberContext() : base("DefaultConnection")
        {
        }
        public DbSet<subscriber> Subscribers { get; set; }
        public DbSet<SubscriberDetail> SubscriberDetails { get; set; }

    }
}