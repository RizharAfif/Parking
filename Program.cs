﻿using System;

namespace ParkingLot
{
  class Program
  {
    static void Main(string[] args)
    {
      ParkingApps system = null;

      string inputUser;
      while ((inputUser = Console.ReadLine()) != "exit")
      {
        var inputs = inputUser.Split(" ");
        switch (inputs[0])
        {
          case "create_parking_lot":
            int totalLots = int.Parse(inputs[1]);
            system = new ParkingApps(totalLots);
            Console.WriteLine($"Created a parking lot with {totalLots} slots");
            break;

          case "park":
            system?.ParkVehicle(inputs[1], inputs[2], inputs[3]);
            break;
          case "leave":
            system?.RemoveVehicle(int.Parse(inputs[1]));
            break;
          case "status":
            system?.ShowStatusVehicle();
            break;
          case "type_of_vehicles":
            system?.CountVehiclesByType(inputs[1]);
            break;
          case "registration_numbers_for_vehicles_with_colour":
            system?.GetVehiclesByColor(inputs[1]);
            break;
          case "slot_numbers_for_vehicles_with_colour":
            system?.GetSlotByVehicleColor(inputs[1]);
            break;
          case "slot_number_for_registration_number":
            system?.GetSlotByRegistrationNumber(inputs[1]);
            break;

          default:
            Console.WriteLine("Invalid input");
            break;
        }
      }
    }
  }
}