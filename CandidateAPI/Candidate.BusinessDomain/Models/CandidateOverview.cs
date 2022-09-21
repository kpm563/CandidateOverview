using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CandidateAPI
{
    [Table("CandidateOverview")]
    public partial class CandidateOverview
    {
        [Key]
        [Column("ID")]
        public Guid Id { get; set; }
        [StringLength(250)]
        [Unicode(false)]
        public string? Name { get; set; }
        [Unicode(false)]
        public string? Address { get; set; }
        [Column("mobile")]
        [StringLength(10)]
        [Unicode(false)]
        public string? Mobile { get; set; }
        [Column("email")]
        [StringLength(255)]
        [Unicode(false)]
        public string? Email { get; set; }
        [StringLength(255)]
        [Unicode(false)]
        public string? FileName { get; set; }
    }
}
