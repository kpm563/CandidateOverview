using Candidate.BusinessDomain.DBOperations;
using Candidate.BusinessDomain.Interfaces;
using Candidate.BusinessDomain.ViewModels;
using CandidateAPI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate.BusinessDomain.Services
{
    public class CandidateService : ICandidateService
    {

        public async Task SaveCandidateAsync(FileUploadRequest request)
        {
			try
			{
                var result = Guid.Empty;
                // Upload file to File Table
                var @params = new List<KeyValuePair<string, object>>();
                @params.Add(new KeyValuePair<string, object>("@fileName", request.FileName));
                @params.Add(new KeyValuePair<string, object>("@fileData", request.FileData));

                var res = await SqlOperation.GetDataFromSQLAsync<string>("usp_save_files", CommandType.StoredProcedure, null, @params);
                if (res.Count>0)
                {
                    result = new Guid(res.First());
                }

                if (result != Guid.Empty)
                {
                    var data = new CandidateOverview
                    {
                        Id = result,
                        Address = request.Address,
                        Email = request.Email,
                        FileName = request.FileName,
                        Mobile = request.Mobile,
                        Name = request.Name
                    };

                    using (var context = new DevOnContext())
                    {
                        context.CandidateOverviews.Add(data);
                        context.SaveChanges();
                    }
                }
			}
			catch (Exception ex)
			{
                Console.WriteLine(ex);
			}
        }

        public async Task<CandidatesResponse> GetAllCandidatesAsync()
        {
            var response = new CandidatesResponse();

            try
            {
                using (var context = new DevOnContext())
                {
                    response.Candidates = context.CandidateOverviews.Select(x => x).ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return response;
        }
    }
}
