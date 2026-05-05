using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Danilkova_453504.Application.SongUseCases.Commands
{
    public sealed record DeleteSongCommand(int SongId) : IRequest<Unit>
    {
    }



    internal class DeleteSongCommandHandler : IRequestHandler<DeleteSongCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteSongCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteSongCommand request, CancellationToken token)
        {
            var song = await _unitOfWork.SongRepository.GetByIdAsync(request.SongId, token);


            if (song != null)
            {

                await _unitOfWork.SongRepository.DeleteAsync(song, token);

                await _unitOfWork.SaveAllAsync();
            }

            return Unit.Value;
        }


    }
}
