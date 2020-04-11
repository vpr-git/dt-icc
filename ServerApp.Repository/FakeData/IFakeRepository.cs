using ServerApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServerApp.Repository.FakeData
{
    public interface IFakeRepository
    {
        List<Vehicle> AllVehicles { get; }
        List<Vehicle> SoldMostVehicles { get; }

    }
}
