using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Coursat.Models
{
    public class DB_CONNECTION : DbContext
    {
        public DB_CONNECTION() : base("COURSAT") //Name of DB
        {

        }

        public DbSet<USER> Users { get; set; }

        public DbSet<ADMIN> Admins { get; set; }

        public DbSet<COURSE> Course { get; set; }
    }
}