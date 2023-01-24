using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VodusDomainLayer.Model;

namespace VodusInfrastructureLayer.Services
{
   public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<PageContent> vodus { get; set; }
    }
}
