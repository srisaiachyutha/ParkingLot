using System;
using ParkingLot.Models;
using ParkingLot.Enums;

namespace ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            ParkingArea p = new ParkingArea();

            Console.WriteLine("Enter the 2 wheeler parking count");
            p.TwoWheelers = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the 4 wheeler parking count");
            p.FourWheelers = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the heavy vehicles parking count");
            p.HeavyVehicles = Convert.ToInt32(Console.ReadLine());

            while (true)
            {
                Console.WriteLine("1. See parking details\n2.Park Vehicle\n3.Unpark Vehicle\nEnter the choice\n");

                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        // parking details
                        p.ShowDetails();
                        break;
                    case 2:
                        // park vehicle
                        Console.WriteLine("choose the options below");
                        Console.WriteLine("1. two Wheeler\n2. four wheeler \n3. heavy vehicles");
                        int parkChoice = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("enter the vehicle number");
                        int vehicle = Convert.ToInt32(Console.ReadLine());

                        switch (parkChoice)
                        {
                            case 1:
                                if (p.TwoWheelers > 0)
                                {
                                    p.TwoWheelers -= 1;
                                    p.AddVehicleNumber(vehicle, VehicleType.TWO);
                                    Console.WriteLine("the vehicle has parked successfully");
                                }
                                else
                                {
                                    Console.WriteLine(" the slots are not empty ");
                                }
                                break;
                            case 2:
                                if (p.FourWheelers > 0)
                                {
                                    p.FourWheelers -= 1;
                                    p.AddVehicleNumber(vehicle, VehicleType.FOUR);
                                    Console.WriteLine("the vehicle has parked successfully");

                                }
                                else
                                {
                                    Console.WriteLine(" the slots are not empty ");
                                }
                                break;
                            case 3:
                                if (p.HeavyVehicles > 0)
                                {
                                    p.HeavyVehicles -= 1;
                                    p.AddVehicleNumber(vehicle, VehicleType.HEAVY);
                                    Console.WriteLine("the vehicle has parked successfully");

                                }
                                else
                                {
                                    Console.WriteLine(" the slots are not empty ");
                                }
                                break;
                        }
                        break;

                    case 3:
                        // Unpark vehicle
                        Console.WriteLine("enter the vehicle number");
                        int v = Convert.ToInt32(Console.ReadLine());
                        if (p.RemoveVehicle(v))
                        {
                            Console.WriteLine("the vehicle is removed from park lot");
                        }
                        else
                        {
                            Console.WriteLine("Please enter a correct vehicle number");
                        }
                        break;
                    default:
                        // choose a good number
                        Console.WriteLine("please choose the number from menu");
                        break;
                }

                Console.WriteLine("y (or) n for continue  (or) exit");
                if (Console.ReadLine() == "n")
                {
                    break;
                }
            }
        }
    
    }
}
