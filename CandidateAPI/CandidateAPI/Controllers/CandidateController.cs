using Candidate.BusinessDomain.Interfaces;
using CandidateAPI.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CandidateAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        public ICandidateService _candidateService;
        public CandidateController(ICandidateService candidateService)
        {
            _candidateService = candidateService;
        }

        [HttpPost("CreateCandidate")]
        public async Task<IActionResult> CreateCandidate()
        {
            try
            {
                var data = Request.GetUploadRequestData();
                await _candidateService.SaveCandidateAsync(data);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpGet("Candidates")]
        public async Task<IActionResult> GetCandidates()
        {
            try
            {
                var response = _candidateService.GetAllCandidatesAsync();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }
        
    }
}
