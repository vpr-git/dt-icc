using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json;
using ServerApp.Models;
using ServerApp.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ServerApp.Controllers
{
    [Route("api/file")]
    [ApiController]
    [AutoValidateAntiforgeryToken]
    public class FileController : Controller
    {
        private IWebHostEnvironment HostEnvironment;
        private readonly IConfiguration Configuration;
        public FileController(IWebHostEnvironment environment, IConfiguration configuration)
        {
            HostEnvironment = environment;
            Configuration = configuration;
        }

        [HttpPost]
        public IActionResult SaveCSVFileData()
        {
            IFormFile file = null;
            string filePath = null;
            try
            {
               file = Request.Form.Files[0];
                string fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                string uploadFolderName = Configuration["Data:Identity:UploadFolderName"];
                string destinationPath = Path.Combine(HostEnvironment.WebRootPath, uploadFolderName);
                filePath = Path.Combine(destinationPath, fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured while storing csv file" + ex.Message);
            }
            return Ok(new { data = filePath });
        }
    }
}
