using ServerApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServerApp.Repository
{
    public interface IDataAccess
    {
        public List<Vehicle> ReadFileData(string filePath, List<Vehicle> listVehicles, string category, bool metadata = false);
    }
}
