namespace InnoTech.Test.Helpers.Locations
{
    public class LocationEntityTestHelper
    {
        public Core.Entity.Location LocationWithoutName(string name = "")
        {
            return new Core.Entity.Location
            {
                Name = name
            };
        }
        
        public Core.Entity.Location LocationWithoutAddress(string address = "")
        {
            var location = LocationWithoutName("The Village");
            location.Address = address;
            return location;
        }

        public Core.Entity.Location LocationWithoutOwner(string owner = "")
        {
            var location = LocationWithoutAddress("The Place");
            location.Owner = owner;
            return location;
        }

        public Core.Entity.Location LocationWithoutId(int id = 0)
        {
            var location = LocationWithoutOwner("John doe");
            location.Id = id;
            return location;
        }

        public Core.Entity.Location ValidLocation()
        {
            return new Core.Entity.Location
            {
                Name = "The Village",
                Address = "The Place",
                Owner = "John Doe"
            };
        }
    }
}