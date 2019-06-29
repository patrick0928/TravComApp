using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravCom.Model;

namespace TravCom.DbLayer
{
    public class InvoiceContext : DbContext
    {
        public InvoiceContext() : base("TravComDb") { }
        public DbSet<Invoice> GetInvoices { get; set; }
    }
}
