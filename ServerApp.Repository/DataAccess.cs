using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.VisualBasic.FileIO;
using ServerApp.Models;
using System.IO;

namespace ServerApp.Repository
{
    /// <summary>
    /// Static Class that has all the methods for retrieving data
    /// </summary>
    public class DataAccess:IDataAccess
    {
        /// <summary>
        /// Reads the csv file in server and retrieves the vehicle information. 
        /// category parameter is used to retrieve the vehicles sold most often
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="listVehicles"></param>
        /// <param name="category"></param>
        /// <param name="metadata"></param>
        /// <returns></returns>
        public List<Vehicle> ReadFileData(string filePath,List<Vehicle> listVehicles, string category, bool metadata = false)
        {
            List<Vehicle> categoryListVehicles = null;
            string strVehicleNameFiltered = string.Empty;
            try
            {
                using (TextFieldParser parser = new TextFieldParser(filePath, Encoding.GetEncoding("ISO-8859-1")))
                {

                    parser.SetDelimiters(new string[] { "," });
                    parser.HasFieldsEnclosedInQuotes = true;

                    parser.ReadFields();
                    while (!parser.EndOfData)
                    {
                        var line = parser.ReadFields();
                        var v = new Vehicle();
                        v.DealNum = Convert.ToInt64(line[0]);
                        v.CustomerName = line[1];
                        v.DealershipName = line[2];
                        v.VehicleName = line[3];
                        v.Price = line[4];
                        v.SaleDate = line[5];
                        listVehicles.Add(v);
                    }
                }
                if (!string.IsNullOrWhiteSpace(category) && category.Equals("soldmost"))
                {
                    var query = listVehicles.GroupBy(x => x.VehicleName)
                     .Select(group => new { VehicleName = group.Key, Count = group.Count() }).OrderByDescending(x => x.Count).FirstOrDefault();
                    strVehicleNameFiltered = query.VehicleName;
                    categoryListVehicles = listVehicles.Where(x => x.VehicleName == strVehicleNameFiltered).OrderBy(x=>x.DealNum).ToList<Vehicle>();
                }
            }
            catch(FileNotFoundException ex)
            {
                listVehicles = null;
                /*
                    Implement Logging for Tracking and Analysis 
                */
            }
            catch (Exception ex)
            {
                listVehicles = null;
                /*
                   Implement Logging for Tracking and Analysis 
               */
                throw new Exception("Error occured while fetching vehicle data - Generic Error" + ex.Message);
            }
            
            return categoryListVehicles != null && categoryListVehicles.Count() > 0 ? categoryListVehicles: listVehicles;

        }
             
    }
}
