using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Danilkova_453504.Persistence.Repositories
{
    public class FakeSongRepository : IRepository<Song>
    {
        List<Song> _songs = new List<Song>();

        public FakeSongRepository()
        {
            for(int i = 1; i <= 2; i++)
            {
                for (int j = 1; j <= 10; j++)
                {
                    var song = new Song(new SongDetails("Melody", 3.78, "Pop"), 3);
                    song.AddSongToSinger(i);
                    _songs.Add(song);
                }

            }
        }



        public async Task<IReadOnlyList<Song>> ListAsync(Expression<Func<Song, bool>> filter,
           CancellationToken cancellationToken = default, params Expression<Func<Song, object>>[]? includesProperties)
        {
            var data = _songs.AsQueryable();
            return data.Where(filter).ToList();
        }



        //пока не реализовываем 
        public Task<Song> GetByIdAsync(int id, CancellationToken cancellationToken = default, params Expression<Func<Song, object>>[]? includesProperties) => throw new NotImplementedException();
        public Task<IReadOnlyList<Song>> ListAllAsync(CancellationToken cancellationToken = default) => throw new NotImplementedException();
        public Task AddAsync(Song entity, CancellationToken cancellationToken = default) => throw new NotImplementedException();
        public Task UpdateAsync(Song entity, CancellationToken cancellationToken = default) => throw new NotImplementedException();
        public Task DeleteAsync(Song entity, CancellationToken cancellationToken = default) => throw new NotImplementedException();
        public Task<Song> FirstOrDefaultAsync(Expression<Func<Song, bool>> filter, CancellationToken cancellationToken = default) => throw new NotImplementedException();

    }
}
