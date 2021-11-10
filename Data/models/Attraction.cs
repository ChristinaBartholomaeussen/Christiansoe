namespace christiansoe.Data.models
{
    public class Attraction
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public bool IsChecked { get; set; } = false;

        public override string ToString()
        {
            return $"{Name} {Latitude} {Longitude}";
        }
    }
}