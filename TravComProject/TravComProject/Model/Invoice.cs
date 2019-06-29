using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravCom.Model
{
    [Table("IfInvoices")]
    public class Invoice
    {
        [Key]
        public int? Record { get; set; }
        public string IdData { get; set; }
        public string IfMenu { get; set; }
        public string RecordLocator { get; set; }
        public string ProfileName { get; set; }
        public string InvoiceNumber { get; set; }
        public string ProfileNumber { get; set; }
        public DateTime? BookingDate { get; set; }
        public DateTime? InvoiceDate { get; set; }
    }
}
