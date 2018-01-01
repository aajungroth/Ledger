using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Ledger.Models
{
    public class ReviewClass
    {
        public int ID { get; set; }
        [Key]
        [ForeignKey("Book")]
        public int BookID { get; set; }
        public string ReviewerName;
        public string Body;
    }
}
