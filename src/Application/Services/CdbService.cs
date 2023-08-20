using Application.Dtos;
using Entities = Cdb.Domain.Entities;
using MediatR;
using Application.Servico;
using Domain.Validators;
using FluentValidation;

namespace Application.Services
{
    public class CdbService: IRequestHandler<CdbServiceRequest, CdbServiceResponse>, ICdbService
    {
        private readonly CdbValidator _validator;

        public CdbService(CdbValidator validator)
        {
            _validator = validator;
        }

        public Task<CdbServiceResponse> Handle(CdbServiceRequest request, CancellationToken cancellationToken)
        {
            var cdb = new Entities.Cdb(request.Cash, request.Deadline);

            var result = _validator.Validate(cdb);

            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }

            var response = new CdbServiceResponse
            {
                GrossResult = Entities.Cdb.CalculateGrossIncome(request.Cash, request.Deadline),
                LiquidResult = Entities.Cdb.CalculateLiquidIncome(request.Cash, request.Deadline)
            };

            return Task.FromResult(response);
        }
    }
}
