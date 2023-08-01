using MediatR;

namespace CarWorkshop.Application.CarWorkshop.Commands.Queries.GetCarWorkshopByEncodedName
{
    public class GetCarWorkshopByEncodenNameQuery : IRequest<CarWorkshopDto>
    {
        public string EncodedName { get; set; }

        public GetCarWorkshopByEncodenNameQuery(string encodedName)
        {
            EncodedName = encodedName;
        }
    }
}
