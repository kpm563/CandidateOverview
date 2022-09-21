using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CandidateAPI;

namespace Candidate.BusinessDomain.ViewModels
{
    public class CandidatesResponse
    {
        public List<CandidateOverview> Candidates { get; set; } = new List<CandidateOverview>();
    }
}
