using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WarunkStream.Models
{
    [Table("Events")]
    public class Event
    {
        [Key]
        public string IdEvent { get; set; }
        public string TitleEvent { get; set; }
        public bool IsPaid { get; set; }
        public Categories Categories { get; set; }
    }
    public enum Categories
    {
        PUBGM,
        ML,
        FF
    }
}