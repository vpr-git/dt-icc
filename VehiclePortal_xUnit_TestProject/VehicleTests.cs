using ServerApp.Models;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using ServerApp.Controllers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Moq;
using ServerApp.Repository;
using System.Collections.Generic;
using System;
using ServerApp.Repository.FakeData;

namespace ServerApp_xUnit_TestProject.Tests
{
    public class VehicleTests
    {
        private string filePath;
        private List<Vehicle> vehicles;
        private IFakeRepository respository;
        private IDataAccess dataAccess;
        public VehicleTests()
        {
            filePath = "C:\\Users\\Neetha\\source\\repos\\DealerTrack\\ServerApp\\wwwroot\\uploads\\Dealertrack-CSV-Example.csv";
            vehicles = new List<Vehicle>();
            respository = new SimpleRepository();
            dataAccess = new DataAccess();
        }

        [Fact]
        public void GetAllVehicles()
        {
            var result = dataAccess.ReadFileData(filePath, vehicles, null, true);
            Assert.Equal(respository.AllVehicles, result,
                Comparer.Get<Vehicle>((v1, v2) =>
                v1.DealNum == v2.DealNum &&
                v1.DealershipName == v2.DealershipName &&
                v1.CustomerName == v2.CustomerName &&
                v1.VehicleName == v2.VehicleName &&
                v1.Price == v2.Price &&
                v1.SaleDate == v2.SaleDate
                ));
        }
        [Fact]
        public void GetVehicleSoldMost()
        {
            var result = dataAccess.ReadFileData(filePath, vehicles, "soldmost", true);
            Assert.Equal(respository.SoldMostVehicles, result,
                Comparer.Get<Vehicle>((v1, v2) =>
                v1.DealNum == v2.DealNum &&
                v1.DealershipName == v2.DealershipName &&
                v1.CustomerName == v2.CustomerName &&
                v1.VehicleName == v2.VehicleName &&
                v1.Price == v2.Price &&
                v1.SaleDate == v2.SaleDate
                ));
        }




    }
}
