using MediatR;

namespace CarWorkshop.Application.CarWorkshop.Commands.Queries.GetAllCarWorkshops
{
    public class GetAllCarWorkshopsQuery : IRequest<IEnumerable<CarWorkshopDto>>
    {

    }
}
