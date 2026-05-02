using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Danilkova_453504.Application.SongUseCases.Commands
{
    public sealed record UpdateSongCommand(int Id, string Name, double Continuation, string Genre, int Rate) : IRequest<Unit>
    {
    }


    internal class UpdateSongCommandHandler : IRequestHandler<UpdateSongCommand, Unit>
    {

        private readonly IUnitOfWork _unitOfWork;

        public UpdateSongCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateSongCommand request, CancellationToken token)
        {
            var song = await _unitOfWork.SongRepository.GetByIdAsync(request.Id, token);

            if (song == null) return Unit.Value;


            song.UpdateSong(request.Name, request.Continuation, request.Genre, request.Rate);

            await _unitOfWork.SongRepository.UpdateAsync(song, token);
            await _unitOfWork.SaveAllAsync();

            return Unit.Value;

        }


    }

}
