namespace christiansoe.Data.models
{
    public class Attraction
    {
        // init bruges, da den kun skal sættes når objektet instantieres
        public int Id { get; init; }
        public string Name { get; init; }
        public double Latitude { get; init; }
        public double Longitude { get; init; }

        public bool IsChecked { get; set; }

        public override string ToString()
        {
            return $"{Name} {Latitude} {Longitude}";
        }
    }
}