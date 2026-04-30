using Danilkova_453504.Application.SingerUseCases.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Danilkova_453504.Application.SongUseCases.Queries
{
    public  sealed record GetSongsBySingerRequest(int Id) : IRequest<IEnumerable<Song>>
    {

    }


    internal class GetSongsBySingerRequestHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetSongsBySingerRequest, IEnumerable<Song>>
    {
        public async Task<IEnumerable<Song>> Handle(GetSongsBySingerRequest request, CancellationToken cancellationToken)
        {
            return await unitOfWork.SongRepository.ListAsync(s => s.SingerId.Equals(request.Id), cancellationToken);
        }


    }
}
