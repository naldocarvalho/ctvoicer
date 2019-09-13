using System;

namespace Domain.Entities
{
    public class Vehicle : EntityGeneric
    {
        public string Chassis { get; set; }
        public string Color { get; set; }
        public string Type { get; set; }
        public byte PassengerCapacity { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime? DateUpdate { get; set; }

        public Vehicle() { }

        public Vehicle(string chassis, string type, string color)
        {
            Chassis = chassis;
            Type = type;
            Color = color;
        }
    }
}