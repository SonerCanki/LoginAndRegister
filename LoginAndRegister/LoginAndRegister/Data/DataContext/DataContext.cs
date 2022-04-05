using LoginAndRegister.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LoginAndRegister.Data.DataContext
{
    public class DataContext:DbContext
    {
        public DataContext():base("Name=Conn")
        {

        }
        public DbSet<ApplicationUser> Users { get; set; }
    }
}