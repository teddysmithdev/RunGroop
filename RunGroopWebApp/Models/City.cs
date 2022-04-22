namespace RunGroopWebApp.Models
{
    public class City
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public string StateCode { get; set; }
        public int Zip { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string County { get; set; }
    }
}
