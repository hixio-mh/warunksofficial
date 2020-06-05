using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WarunkStream.Models
{
    [Table("Certificates")]
    public class Certificate
    {
        [Key]
        public string IdCertificate { get; set; }
        public string UrlDocument { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset Finished { get; set; }
        public Team Team { get; set; }
        public bool IsTournament { get; set; }
        public bool IsFarisStore { get; set; }
        public bool IsSpotify { get; set; }
    }
}