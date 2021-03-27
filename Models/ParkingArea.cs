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

        public void AddVehicleNumber(int vehicleNumber, VehicleType v)
        {
            Random r = new Random();
            int n;
            do
            {
                n = r.Next(1, 1000);
            } while (this._dict.ContainsKey(n.ToString()));

            this._dict.Add(vehicleNumber.ToString(), new Ticket(vehicleNumber, n, v, DateTime.Now));
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
                return true;
            }
            return false;
        }

        public void ShowDetails()
        {
            Console.WriteLine("there are " + this._twoWheelers.ToString() +
            " two wheeler empty slots " + this._fourWheelers.ToString() +
            " Four wheeler empty slots " + this._heavyVehicles.ToString() +
            " heavy vehicles"
            );
            foreach (KeyValuePair<string, Ticket> item in this._dict)
            {
                Console.WriteLine(@"slot number: {0} vehicle number: {1} ", item.Value.SlotNumber().ToString(), item.Value.NumberPlate());
            }
        }
    }
}
