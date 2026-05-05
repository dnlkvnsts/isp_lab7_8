using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Danilkova_453504.Application.SongUseCases.Queries
{
    public sealed record GetSongByIdQuery(int Id) : IRequest<Song>;

    
    internal class GetSongByIdHandler : IRequestHandler<GetSongByIdQuery, Song>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetSongByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Song> Handle(GetSongByIdQuery request, CancellationToken token)
        {
            
            var song = await _unitOfWork.SongRepository.GetByIdAsync(request.Id, token);

            return song;
        }
    }
}
