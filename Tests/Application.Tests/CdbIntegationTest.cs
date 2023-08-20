using Application.Dtos;
using Application.Services;
using Domain.Validators;

namespace Application.Tests
{
    public class CdbIntegationTest
    {
        [Theory]
        [InlineData(100, 105.975)]
        [InlineData(100, 104.955)]
        public void Deve_retornar_resultado_bruto_correto(decimal cash, decimal expectedValue)
        {
            var handler = new CdbService(new CdbValidator());
            var command = new Dtos.CdbServiceRequest
            {
                Deadline = 6,
                Cash = cash
            };

            var result = handler.Handle(command, CancellationToken.None).Result;

            Assert.Equal(expectedValue, result.GrossResult);

        }

        [Theory]
        [InlineData(100, 6, 105.97)]
        [InlineData(100, 8, 104.95)]
        [InlineData(100, 12, 104.95)]
        [InlineData(100, 18, 104.95)]
        [InlineData(100, 24, 104.95)]
        [InlineData(100, 26, 104.95)]
        public void Deve_retornar_resultado_liquido(decimal cash, int deadline, decimal expectedValue)
        {
            var handler = new CdbService(new CdbValidator());
            var command = new CdbServiceRequest
            {
                Deadline = deadline,
                Cash = cash
            };

            var result = handler.Handle(command, CancellationToken.None).Result;

            Assert.Equal(expectedValue, result.LiquidResult);
        }
    }
}