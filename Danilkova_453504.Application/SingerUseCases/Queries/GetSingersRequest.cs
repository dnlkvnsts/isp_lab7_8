using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Danilkova_453504.Application.SingerUseCases.Queries
{
    public sealed record GetSingersRequest() : IRequest<IEnumerable<Singer>>
    {
    }


    internal class GetSingersRequestHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetSingersRequest, IEnumerable<Singer>>
    {
        public async Task<IEnumerable<Singer>> Handle (GetSingersRequest request, CancellationToken cancellationToken)
        {
            return await unitOfWork.SingerRepository.ListAllAsync(cancellationToken);
        }
    }
}
