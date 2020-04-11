using System;
using System.Collections.Generic;
using System.Collections;
using ServerApp.Models;

namespace ServerApp_xUnit_TestProject.Tests
{
    public class VehicleTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { GetAllVehicles() };
            yield return new object[] { GetVehiclesSoldMost() };
        }

        private object GetVehiclesSoldMost()
        {
            return new Vehicle[]
            {
                new Vehicle{DealNum =5212, CustomerName="Richard Spencer", DealershipName="Milton Jeep Limited", VehicleName="2018 Jeep Grand Cherokee Trackhawk", Price="134,599",SaleDate="7/13/2018"  },
                new Vehicle{DealNum =5812, CustomerName="Anwar Hoffman", DealershipName="Legowart Kingorty, Ltd.", VehicleName="2018 Jeep Grand Cherokee Trackhawk", Price="130,936",SaleDate="5/11/2018"  },
                new Vehicle{DealNum =5712, CustomerName="Donald Waters", DealershipName="Milton Jeep Limited", VehicleName="2018 Jeep Grand Cherokee Trackhawk", Price="135,500",SaleDate="6/21/2018"  }

            };
        }

        private object GetAllVehicles()
        {
            return new Vehicle[]
            {
                new Vehicle{DealNum =5469, CustomerName="Milli Fulton", DealershipName="Sun of Saskatoon", VehicleName="2017 Ferrari 488 Spider", Price="429,987",SaleDate="6/19/2018"  },
                new Vehicle{DealNum =5132, CustomerName="Rahima Skinner", DealershipName="Seven Star Dealership", VehicleName="2009 Lamborghini Gallardo Carbon Fiber LP-560", Price="169,900",SaleDate="1/14/2018"  },
                new Vehicle{DealNum =5795, CustomerName="Aroush Knapp", DealershipName="Maxwell & Junior", VehicleName="2016 Porsche 911 2dr Cpe GT3 RS", Price="289,900",SaleDate="6/7/2018"  },
                new Vehicle{DealNum =5212, CustomerName="Richard Spencer", DealershipName="Milton Jeep Limited", VehicleName="2018 Jeep Grand Cherokee Trackhawk", Price="134,599",SaleDate="7/13/2018"  },
                new Vehicle{DealNum =5268, CustomerName="Naseem Snow", DealershipName="Scott Toronto Dealership, Inc", VehicleName="2018 BMW M760Li Xdrive Sedan", Price="177,608",SaleDate="1/21/2018"  },
                new Vehicle{DealNum =5765, CustomerName="Storm William", DealershipName="Mythicgarcia Dealership LTDA", VehicleName="2018 Mercedes-Benz S-Class Cabriolet", Price="189,693",SaleDate="3/22/2018"  },
                new Vehicle{DealNum =5465, CustomerName="Ségolène Lémery", DealershipName="Richaremus Jafur Dealer", VehicleName="2017 Chevrolet Corvette Z06", Price="132,925",SaleDate="3/4/2018"  },
                new Vehicle{DealNum =5545, CustomerName="Élie Boutroux", DealershipName="Horseallen Cars", VehicleName="2018 Lexus LS 500h", Price="164,810",SaleDate="2/5/2018"  },
                new Vehicle{DealNum =5890, CustomerName="Ronnie Griffiths", DealershipName="Cheruharrison Auto", VehicleName="2018 Nissan GT-R Premium", Price="147,018",SaleDate="4/8/2018"  },
                new Vehicle{DealNum =5812, CustomerName="Anwar Hoffman", DealershipName="Legowart Kingorty, Ltd.", VehicleName="2018 Jeep Grand Cherokee Trackhawk", Price="130,936",SaleDate="5/11/2018"  },
                new Vehicle{DealNum =5298, CustomerName="Jakob Osborn", DealershipName="Coreen Dealership", VehicleName="2017 Dodge Viper New Car ACR", Price="229,998",SaleDate="6/11/2018"  },
                new Vehicle{DealNum =5359, CustomerName="Maxine Daniels", DealershipName="Saskatoon Ferrari", VehicleName="2017 Ferrari 488 Spider", Price="419,955",SaleDate="7/15/2018"  },
                new Vehicle{DealNum =5712, CustomerName="Donald Waters", DealershipName="Milton Jeep Limited", VehicleName="2018 Jeep Grand Cherokee Trackhawk", Price="135,500",SaleDate="6/21/2018"  }

            };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
