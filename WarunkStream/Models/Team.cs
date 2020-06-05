using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WarunkStream.Models
{
    [Table("Teams")]
    public class Team
    {
        [Key]
        public string IdTeam { get; set; }
        public string NameTeam { get; set; }
        public string EmailTeam { get; set; }
        public string PhoneTeam { get; set; }
        public List<MemberTeam> MemberTeams { get; set; }
    }
    [Table("MemberTeams")]
    public class MemberTeam
    {
        [Key]
        public string IdMemberTeam { get; set; }
        public string Nick { get; set; }
        public string ID { get; set; }
    }
}