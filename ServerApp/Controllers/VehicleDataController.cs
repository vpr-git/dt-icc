using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic.FileIO;
using Microsoft.Extensions.Configuration;
using ServerApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ServerApp.Repository;

namespace ServerApp.Controllers
{
    
    [Route("api/vehicles")]
    [ApiController]
   [AutoValidateAntiforgeryToken]
    public class VehicleDataController:Controller
    {
        private IWebHostEnvironment HostEnvironment;
        private readonly IConfiguration Configuration;
        private IDataAccess DataAccess;
        public VehicleDataController(IWebHostEnvironment environment,IConfiguration configuration,IDataAccess dataAccess)
        {
            HostEnvironment = environment;
            Configuration = configuration;
            DataAccess = dataAccess;
        }
        /// <summary>
        /// Method to get the list of all / category based vehicles from Repository
        /// </summary>
        /// <param name="category"></param>
        /// <param name="metadata"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetVehicles(string category,bool metadata = false)
        {
            string fileName = Configuration["Data:Identity:CSVFileName"];
            string uploadFolderName = Configuration["Data:Identity:UploadFolderName"];

            string rootPath = HostEnvironment.WebRootPath ?? Configuration["Data:Identity:RootPath"];
               
            string destinationPath = Path.Combine(rootPath, uploadFolderName);
            string filePath = Path.Combine(destinationPath, fileName);
            List<Vehicle> listVehicles = new List<Vehicle>();
            listVehicles = DataAccess.ReadFileData(filePath, listVehicles,category,metadata);
            return metadata ? CreateVehicleMetaData(listVehicles) : Ok(listVehicles);
        }
        /// <summary>
        /// Helper method to create vehicle meta data that will return IActionResult object to Angular
        /// </summary>
        /// <param name="listVehicles"></param>
        /// <returns></returns>
        private IActionResult CreateVehicleMetaData(List<Vehicle> listVehicles)
        {
            VehicleMetaData metaData = new VehicleMetaData();
            metaData.categories = new List<string>() { "All", "SoldMost" };
            metaData.data = listVehicles;
            return Ok(metaData);
        }
    }
}
