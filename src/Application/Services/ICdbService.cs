using Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Servico
{
    public interface ICdbService
    {
        Task<CdbServiceResponse> Handle(CdbServiceRequest request, CancellationToken cancellationToken);
    }
}
