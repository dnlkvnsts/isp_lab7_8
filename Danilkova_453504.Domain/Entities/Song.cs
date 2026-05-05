
namespace Danilkova_453504.Domain.Entities
{
    public class Song : Entity
    {
        private Song()
        {

        }

        public Song(SongDetails songDetails, int? rate)
        {
            SongInformation = songDetails;
            Rate = rate.Value;
        }

        public SongDetails SongInformation { get; private set; }

        public int Rate { get; private set; }

        public int? SingerId { get; private set; }



        public void AddSongToSinger(int singerId)
        {
            if (singerId <= 0) return;
            SingerId = singerId;
        }


        public void UpdateSong(string name, double continuation, string genre, int rate)
        {
            SongInformation = new SongDetails(name, continuation, genre);
            ChangeRate(rate);
        }


        public void ChangeRate(int rate)
        {
            if (rate <= 0 || rate > 100) return;
            Rate = rate;
        }

        public void TakeSongFromSinger()
        {
            SingerId = 0;
        }

        public void DeleteSong()
        {

        }

        public void ChangeSinger(int newSingerId)
        {
            if (newSingerId <= 0)
                throw new ArgumentException("Singer's Id must be positive");

            SingerId = newSingerId;
        }


    }
}
