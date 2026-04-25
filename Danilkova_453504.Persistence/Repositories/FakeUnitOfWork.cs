using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Danilkova_453504.Persistence.Repositories
{
    public  class FakeUnitOfWork : IUnitOfWork
    {
        private readonly Lazy<IRepository<Song>> _songRepository;
        private readonly Lazy<IRepository<Singer>> _singerRepository;


        public FakeUnitOfWork()
        {
            _singerRepository = new Lazy<IRepository<Singer>>(() => new FakeSingerRepository());
            _songRepository = new Lazy<IRepository<Song>>(() => new FakeSongRepository());
        }

        public IRepository<Singer> SingerRepository => _singerRepository.Value;
        public IRepository<Song> SongRepository => _songRepository.Value;





//не реализовываем 
        public async Task SaveAllAsync()
        {
            await Task.CompletedTask;
        }

        public async Task DeleteDataBaseAsync()
        {
            await Task.CompletedTask;
        }

        public async Task CreateDataBaseAsync()
        {
            await Task.CompletedTask;
        }

    }
}
