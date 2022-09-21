using Candidate.BusinessDomain.ViewModels;
using Microsoft.Extensions.Primitives;
using Microsoft.VisualBasic.FileIO;
using System.Net;
using System.Reflection;
using System.Xml.Linq;

namespace CandidateAPI.Extensions
{
    public static class HttpRequestExtension
    {
        public static string GetHeaderValue(this HttpRequest request, string headerName)
        {
            var headerValue = string.Empty;
            if (request.Headers.TryGetValue(headerName, out StringValues headerValues))
            {
                headerValue = headerValues.FirstOrDefault();
            }
            return headerValue;
        }

        public static FileUploadRequest GetUploadRequestData(this HttpRequest request)
        {
            byte[] fileData = null;
            IFormFile file = request.Form.Files[0];

            using (var memorySTream = new MemoryStream())
            {
                file.OpenReadStream().CopyTo(memorySTream);
                fileData = memorySTream.ToArray();
            }

            var uploadData = new FileUploadRequest()
            {
                Name = request.Form["name"],
                Address = request.Form["address"],
                Mobile = request.Form["mobile"],
                Email = request.Form["email"],
                FileData = fileData,
                FileName = file.FileName,
                FileExtension = Path.GetExtension(file.FileName),
                FileSize = file.Length,
                FileType = request.Form["fileType"],
            };

            return uploadData;
        }
    }
}
