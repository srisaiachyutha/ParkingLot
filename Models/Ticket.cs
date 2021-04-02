using System;
using ParkingLot.Enums;
namespace ParkingLot.Models
{
    public class Ticket
    {
        private VehicleType _type;
        private int _vehicleNumber;
        private int _slotNumber;
        private DateTime _inTime;
        private DateTime _outTime;
        public Ticket(int vehicleNumber,
                      int slotNumber,
                      VehicleType v,
                      DateTime inTime

                      )
        {
            this._inTime = inTime;
            //this._outTime = outTime;
            this._slotNumber = slotNumber;
            this._vehicleNumber = vehicleNumber;
            this._type = v;

        }
        public int SlotNumber()
        {
            return this._slotNumber;
        }
        public VehicleType TypeofVehicle()
        {
            return this._type;
        }
        public int NumberPlate()
        {
            return this._vehicleNumber;
        }
        public DateTime GiveInTime()
        {
            return this._inTime;
        }
    }
}
