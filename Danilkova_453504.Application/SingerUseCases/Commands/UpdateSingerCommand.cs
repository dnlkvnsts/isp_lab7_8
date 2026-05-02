using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Danilkova_453504.Application.SingerUseCases.Commands
{
    public sealed record UpdateSingerCommand(int Id, string Name, int Age, string Country) : IRequest<Unit>
    {
    }


    internal class UpdateSingerCommandHandler : IRequestHandler<UpdateSingerCommand, Unit>
    {

        private readonly IUnitOfWork _unitOfWork;

        public UpdateSingerCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

       public async Task<Unit> Handle(UpdateSingerCommand request,CancellationToken token)
        {
            var singer = await  _unitOfWork.SingerRepository.GetByIdAsync(request.Id, token);

            if (singer == null) return Unit.Value;


            singer.UpdateSinger(request.Name, request.Age, request.Country);

            await _unitOfWork.SingerRepository.UpdateAsync(singer, token);
            await _unitOfWork.SaveAllAsync();

            return Unit.Value;

        }


    }





}
