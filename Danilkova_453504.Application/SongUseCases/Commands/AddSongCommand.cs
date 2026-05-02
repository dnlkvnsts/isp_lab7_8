using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Danilkova_453504.Application.SongUseCases.Commands
{
    public sealed record AddSongCommand(string Name, double Continuation, string Genre, int Rate, int? SingerId) : IRequest<Song>
    {
    }



    internal class AddSongCommandHandler : IRequestHandler<AddSongCommand, Song>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddSongCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Song> Handle(AddSongCommand request, CancellationToken token)
        {
            Song newSong = new Song(new SongDetails(request.Name, request.Continuation, request.Genre), request.Rate);


            if (request.SingerId.HasValue)
            {
                newSong.AddSongToSinger(request.SingerId.Value);
            }

            await _unitOfWork.SongRepository.AddAsync(newSong, token);

            await _unitOfWork.SaveAllAsync();
            return newSong;
        }


    }


}
