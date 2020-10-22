using InnoTech.Core.Entity;

namespace InnoTech.Core.PrimaryDriver.Adapters.Test.Helpers
{
    public class LocationTestHelper
    {
        public Location LocationWithoutName(string name = "")
        {
            return new Location
            {
                Name = name
            };
        }
        
        public Location LocationWithoutAddress(string address = "")
        {
            var location = LocationWithoutName("The Village");
            location.Address = address;
            return location;
        }

        public Location LocationWithoutOwner(string owner = "")
        {
            var location = LocationWithoutAddress("The Place");
            location.Owner = owner;
            return location;
        }

        public Location LocationWithoutId(int id = 0)
        {
            var location = LocationWithoutOwner("John doe");
            location.Id = id;
            return location;
        }

        public Location ValidLocation()
        {
            return new Location
            {
                Name = "The Village",
                Address = "The Place",
                Owner = "John Doe"
            };
        }
    }
}