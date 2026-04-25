using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Danilkova_453504.Persistence.Repositories
{
    public  class FakeSingerRepository : IRepository<Singer>
    {

        List<Singer> _singers;

        public FakeSingerRepository()
        {
            _singers = new List<Singer>();

            var singer = new Singer("Mike", 24, "Belarus");
            singer.Id = 1;
            _singers.Add(singer);
            singer = new Singer("Mila", 38, "Russia");
            singer.Id = 2;
            _singers.Add(singer);
        }

        public async Task<IReadOnlyList<Singer>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            return await Task.Run(() => _singers);
        }


        // for beginning testing there are not useful
        public Task<Singer> GetByIdAsync(int id, CancellationToken cancellationToken = default, params Expression<Func<Singer, object>>[]? includesProperties) => throw new NotImplementedException();
        public Task<IReadOnlyList<Singer>> ListAsync(Expression<Func<Singer, bool>> filter, CancellationToken cancellationToken = default, params Expression<Func<Singer, object>>[]? includesProperties) => throw new NotImplementedException();
        public Task AddAsync(Singer entity, CancellationToken cancellationToken = default) => throw new NotImplementedException();
        public Task UpdateAsync(Singer entity, CancellationToken cancellationToken = default) => throw new NotImplementedException();
        public Task DeleteAsync(Singer entity, CancellationToken cancellationToken = default) => throw new NotImplementedException();
        public Task<Singer> FirstOrDefaultAsync(Expression<Func<Singer, bool>> filter, CancellationToken cancellationToken = default) => throw new NotImplementedException();
    }
}
