using System;
using System.Collections.Generic;
using System.Text;

namespace RepoProject.Core.Entities
{
    public  class CarDetails
    {
        public string Rego { get; set; }
        public string CarMake { get; set; }
        public string CarModel { get; set; }
        public string FuelType { get; set; }
        public int Odometer { get; set; }
        public string FuelLevel { get; set; }
        public string CarCondition { get; set; }
    }
}
