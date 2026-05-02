using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Danilkova_453504.Application.SingerUseCases.Commands
{
    public sealed record CreateSingerCommand(string Name, int Age, string Country) : IRequest<Singer>
    {
    }

    internal class CreateSingerCommandHandler: IRequestHandler<CreateSingerCommand, Singer>
    {

        private readonly IUnitOfWork _unitOfWork;

        public CreateSingerCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Singer> Handle(CreateSingerCommand request, CancellationToken token)
        {
            Singer newSinger = new Singer(request.Name, request.Age, request.Country);

            await _unitOfWork.SingerRepository.AddAsync(newSinger, token);
            await _unitOfWork.SaveAllAsync();

            return newSinger;
        }


    }


}
