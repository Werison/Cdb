using MediatR;

namespace Application.Dtos
{
    public class CdbServiceRequest : IRequest<CdbServiceResponse>
    {
        public decimal Cash { get; set; }
        public int Deadline { get; set; }
    }

}
