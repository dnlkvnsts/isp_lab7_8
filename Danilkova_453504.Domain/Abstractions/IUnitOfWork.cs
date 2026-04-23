using Danilkova_453504.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Danilkova_453504.Domain.Abstractions
{
    public  interface IUnitOfWork
    {
        IRepository<Singer> SingerRepository { get; }
        IRepository<Song> SongRepository {  get; }

        public Task SaveAllAsync();
        public Task DeleteDataBaseAsync();
        public Task CreateDataBaseAsync();


    }
}
