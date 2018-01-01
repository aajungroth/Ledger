using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Ledger.Models
{
    public class BookClass
    {
        public int ID { get; set; }
        [Key]
        [ForeignKey("Author")]
        public int AuthorID { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
