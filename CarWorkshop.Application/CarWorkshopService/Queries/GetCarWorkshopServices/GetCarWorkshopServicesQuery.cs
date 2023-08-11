using MediatR;

namespace CarWorkshop.Application.CarWorkshopService.Queries.GetCarWorkshopServices
{
    public class GetCarWorkshopServicesQuery : IRequest<IEnumerable<CarWorkshopServiceDto>>
    {
        public string EncodedName { get; set; } = default!;
    }
}
