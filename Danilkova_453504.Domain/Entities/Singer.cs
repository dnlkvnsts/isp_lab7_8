

namespace Danilkova_453504.Domain.Entities
{
    public class Singer : Entity
    {

        private List<Song> _songs = new();
        private Singer()
        {

        }


        public Singer(string name, int age, string country)
        {
            Name = name;
            Age = age;
            Country = country;

        }


        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Country { get; private set; }


        public IReadOnlyList<Song> Songs { get => _songs.AsReadOnly(); }

    }
}
