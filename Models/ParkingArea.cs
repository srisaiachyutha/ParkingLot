using System;
using ParkingLot.Enums;
using System.Collections.Generic;
namespace ParkingLot.Models
{
    public class ParkingArea
    {
        private Dictionary<string, Ticket> _dict = new Dictionary<string, Ticket>();
        private int _twoWheelers;
        private int _fourWheelers;
        private int _heavyVehicles;
        public int TwoWheelers
        {
            get { return this._twoWheelers; }
            set { this._twoWheelers = value; }
        }
        public int FourWheelers
        {
            get { return this._fourWheelers; }
            set { this._fourWheelers = value; }
        }
        public int HeavyVehicles
        {
            get { return this._heavyVehicles; }
            set { this._heavyVehicles = value; }
        }

        public int CostForLessThanOneHour { get; set; } = 5; // default 5 rupees
        public int CostForEachHour { get; set; } = 10;
        public void AddVehicleNumber(int vehicleNumber, VehicleType v)
        {
            Random r = new Random();
            int n;
            do
            {   // for generating random slot number
                n = r.Next(1, 1000);
            } while (this._dict.ContainsKey(n.ToString()));

            this._dict.Add(vehicleNumber.ToString(), new Ticket(vehicleNumber, n, v, DateTime.Now));
            Console.WriteLine("the slot number for parking your car is " + n.ToString());
            switch (v)
            {
                case VehicleType.FOUR:
                    this._fourWheelers -= 1;
                    break;
                case VehicleType.HEAVY:
                    this._heavyVehicles -= 1;
                    break;
                case VehicleType.TWO:
                    this._twoWheelers -= 1;
                    break;
            }
        }

        public bool RemoveVehicle(int vehicle)
        {
            if (this._dict.ContainsKey(vehicle.ToString()))
            {
                Ticket t = this._dict[vehicle.ToString()];
                switch (t.TypeofVehicle())
                {
                    case VehicleType.TWO:
                        this._twoWheelers += 1;
                        break;
                    case VehicleType.FOUR:
                        this._fourWheelers += 1;
                        break;
                    case VehicleType.HEAVY:
                        this._heavyVehicles += 1;
                        break;
                }

                this._dict.Remove(vehicle.ToString());
                // for calculating the time difference and calculating the cost
                // for parking 
                DateTime endTime = DateTime.Now;
                TimeSpan span = endTime.Subtract(t.GiveInTime());
                decimal cost = CostForLessThanOneHour; // default cost for parking
                if (span.Hours > 1)
                {
                    // if parking time exceeds more than one hour at that time the cost for 
                    // parking
                    cost += (Math.Ceiling((decimal)span.Hours) - 1) * CostForEachHour;
                }
                Console.WriteLine("the cost for parking your vehicle is " +
                    cost.ToString());
                return true;
            }
            return false;
        }

        public void ShowDetails()
        {
            Console.WriteLine("there are \n" + this._twoWheelers.ToString() +
            " two wheeler empty slots \n" + this._fourWheelers.ToString() +
            " Four wheeler empty slots \n" + this._heavyVehicles.ToString() +
            " heavy vehicles empty slots\n"
            );
            foreach (KeyValuePair<string, Ticket> item in this._dict)
            {
                Console.WriteLine(@"slot number: {0} vehicle number: {1} ", item.Value.SlotNumber().ToString(), item.Value.NumberPlate());
            }
        }
    }
}
