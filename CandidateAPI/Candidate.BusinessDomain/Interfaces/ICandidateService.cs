using Candidate.BusinessDomain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate.BusinessDomain.Interfaces
{
    public interface ICandidateService
    {
        public Task SaveCandidateAsync(FileUploadRequest request);
        public Task<CandidatesResponse> GetAllCandidatesAsync();
    }
}
