using Danilkova_453504.Persistence.Data;


namespace Danilkova_453504.Persistence.Repositories
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly Lazy<IRepository<Song>> _songRepository;
        private readonly Lazy<IRepository<Singer>> _singerRepository;


        public EfUnitOfWork(AppDbContext context)
        {
            _context = context;
            _songRepository = new Lazy<IRepository<Song>>(() => new EfRepository<Song>(context));
            _singerRepository = new Lazy<IRepository<Singer>>(() => new EfRepository<Singer>(context));

        }

        public IRepository<Singer> SingerRepository => _singerRepository.Value;
        public IRepository<Song> SongRepository => _songRepository.Value;


        public async Task SaveAllAsync() => await _context.SaveChangesAsync();
        public async Task DeleteDataBaseAsync() => await _context.Database.EnsureDeletedAsync();
        public async Task CreateDataBaseAsync() => await _context.Database.EnsureCreatedAsync();


    }
}
