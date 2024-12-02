using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkingLot
{
    public class ParkingSystem
    {
        static int _totalLots;
        private readonly Dictionary<int, Vehicle> _parkingLots;

        public ParkingSystem(int totalLots)
        {
            _totalLots = totalLots;
            _parkingLots = new Dictionary<int, Vehicle>();
        }

        public void ParkVehicle(string regNumber, string color, string type)
        {
            if (_parkingLots.Count >= _totalLots)
            {
                Console.WriteLine("Sorry, parking lot is full");
                return;
            }

            int availableSlot = Enumerable.Range(1, _totalLots).FirstOrDefault(slot => !_parkingLots.ContainsKey(slot));
            _parkingLots[availableSlot] = new Vehicle { RegistrationNumber = regNumber, Color = color, Type = type };
            Console.WriteLine($"Allocated slot number: {availableSlot}");
        }
        
        // remove the vehicle
        public void LeaveSlotVehicle(int slotNumber)
        {
            if (_parkingLots.Remove(slotNumber))
                Console.WriteLine($"Slot number {slotNumber} is free");
            else
                Console.WriteLine("Slot not found");
        }
        // end remove the vehicle

        // show status vehicle
        public void ShowStatus()
        {
            Console.WriteLine("Slot\tNo.\tType\tRegistration No\tColour");
            foreach (var slot in _parkingLots)
            {
                Console.WriteLine($"{slot.Key}\t{slot.Value.RegistrationNumber}\t{slot.Value.Type}\t{slot.Value.Color}");
            }
        }
        // end show status vehicle

        // count type vehicle
        public void CountVehiclesByType(string type)
        {
            int count = _parkingLots.Values.Count(v => v.Type == type);
            Console.WriteLine(count);
        }
        // end count type vehicle

        public void GetVehiclesByPlate(bool odd)
        {
            var plates = _parkingLots.Values
                .Where(v => IsOddPlate(v.RegistrationNumber) == odd)
                .Select(v => v.RegistrationNumber);
            Console.WriteLine(string.Join(", ", plates));
        }


        public void GetVehiclesByColor(string color)
        {
            var vehicles = _parkingLots.Values
                .Where(v => v.Color == color)
                .Select(v => v.RegistrationNumber);
            Console.WriteLine(string.Join(", ", vehicles));
        }

        public void getSlotByColor(string color)
        {
            var slot = _parkingLots
            .Where(v => v.Value.Color == color)
            .Select(v => v.Key);
            Console.WriteLine(string.Join(", ", slot));
        }

        public void GetSlotByRegistrationNumber(string regNumber)
        {
            var slot = _parkingLots.FirstOrDefault(v => v.Value.RegistrationNumber == regNumber).Key;
            Console.WriteLine(slot > 0 ? slot.ToString() : "Not found");
        } 

        private static bool IsOddPlate(string plate)
        {
            string lastNumber = plate.Split('-').Last();
            return int.TryParse(lastNumber[^1..], out int num) && num % 2 != 0;
        }
    }
}