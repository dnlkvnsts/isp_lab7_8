using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Danilkova_453504.Application.SongUseCases.Commands
{
    public record AlterSingerCommand(int SongId, int NewSingerId) : IRequest<bool>
    {

    }


    internal class AlterSingerCommandHandler : IRequestHandler<AlterSingerCommand, bool>
    {

        private readonly IUnitOfWork _unitOfWork;

        public AlterSingerCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(AlterSingerCommand request, CancellationToken cancellationToken)
        {
           
            var song = await _unitOfWork.SongRepository.GetByIdAsync(request.SongId, cancellationToken);

            if (song == null) return false;


            song.ChangeSinger(request.NewSingerId);


            await _unitOfWork.SaveAllAsync();

            return true;
        }
    }


}
