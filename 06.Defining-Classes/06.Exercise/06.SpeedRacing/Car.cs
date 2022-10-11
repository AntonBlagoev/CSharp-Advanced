using System;


namespace DefiningClasses
{
    public class Car
    {
        public Car(string model, double fuelAmount, double fuelConsumptionFor1km)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKilometer = fuelConsumptionFor1km;
        }
        private string model;

        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        private double fuelAmount;

        public double FuelAmount
        {
            get { return fuelAmount; }
            set { fuelAmount = value; }
        }
        private double fuelConsumptionPerKilometer;

        public double FuelConsumptionPerKilometer
        {
            get { return fuelConsumptionPerKilometer; }
            set { fuelConsumptionPerKilometer = value; }
        }
        private double travelledDistance;

        public double TravelledDistance
        {
            get { return travelledDistance; }
            set { travelledDistance = value; }
        }

        public void Drive(string carModel, double amountOfKm)
        {
            if (this.fuelAmount >= (this.fuelConsumptionPerKilometer * amountOfKm))
            {
                this.fuelAmount -= (this.fuelConsumptionPerKilometer * amountOfKm);
                this.travelledDistance += amountOfKm;
                return;
            }
            Console.WriteLine("Insufficient fuel for the drive");
        }
    }
}
