using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkingLot
{
    public class ParkingApps
    {
        static int totalParkingLots;
        private readonly Dictionary<int, Vehicle> parkingLots;


        public ParkingApps(int totalLots)
        {
            totalParkingLots = totalLots;
            parkingLots = new Dictionary<int, Vehicle>();
        }

        public void ParkVehicle(string number, string color, string type)
        {
            if (parkingLots.Count >= totalParkingLots)
            {
                Console.WriteLine("Sorry, parking lot is full");
                return;
            }

            int availableSlotParking = Enumerable.Range(1, totalParkingLots).FirstOrDefault(slot => !parkingLots.ContainsKey(slot));
            parkingLots[availableSlotParking] = new Vehicle { RegistrationNumber = number, Color = color, Type = type };
            Console.WriteLine($"Allocated slot Number: {availableSlotParking}");
        }

        // remove vehicle
        public void RemoveVehicle(int slotNumber)
        {
            if (parkingLots.Remove(slotNumber))
            {
                Console.WriteLine($"Slot Number {slotNumber} is free");
            }
            else
            {
                Console.WriteLine("Slot Not Found");
            }
        }
        // end remove vehicle

        // show status vehicle
        public void ShowStatusVehicle()
        {
            Console.WriteLine("Slot\tNo.\tType\tRegistration No\tColour");
            foreach(var slot in parkingLots)
            {
                Console.WriteLine($"{slot.Key}\t{slot.Value.RegistrationNumber}\t{slot.Value.Type}\t{slot.Value.Color}"); // get vehicle
            }
        }
        // end show status vehicle

        // count type vehicle
        public void CountVehiclesByType(string type)
        {
            int countByType = parkingLots.Values.Count(v => v.Type == type);
            Console.WriteLine($"Total {type} vehicles: {countByType}");
        }
        // end count type vehicle

        // get vehicle by colour
        public void GetVehiclesByColor(string colour)
        {
            var vehicleColour = parkingLots.Values
            .Where(v => v.Color == colour)
            .Select(v => v.RegistrationNumber);
            Console.WriteLine(string.Join(", ", vehicleColour));
        }
        // end get vehicle by colour

        // get slot by vehicle colour
        public void GetSlotByVehicleColor(string colour)
        {
            var slotByVehicleColour = parkingLots
            .Where(v => v.Value.Color == colour)
            .Select(v => v.Key);
            Console.WriteLine(string.Join(", ", slotByVehicleColour));
        }
        // end get slot by vehicle colour

        // get slot by registration number
        public void GetSlotByRegistrationNumber(string regNumber)
        {
            var slotByRegistrationNumber = parkingLots.FirstOrDefault(v => v.Value.RegistrationNumber == regNumber).Key;
            Console.WriteLine(slotByRegistrationNumber > 0 ? slotByRegistrationNumber.ToString() : "Not Found");
        }
        // end get slot by registration number
    }
}
