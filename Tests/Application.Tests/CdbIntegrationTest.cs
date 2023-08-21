using Application.Dtos;
using Application.Services;
using Domain.Validators;

namespace Application.Tests
{
    public class CdbIntegrationTest
    {
        [Theory]
        [InlineData(100, 6, 105.98)]
        [InlineData(100, 8, 108.05)]
        [InlineData(100, 12, 112.31)]
        [InlineData(100, 18, 119.02)]
        [InlineData(100, 24, 126.13)]
        [InlineData(100, 26, 128.6)]
        public void Should_return_correct_gross_result(decimal cash, int deadline, decimal expectedValue)
        {
            var handler = new CdbService(new CdbValidator());
            var command = new Dtos.CdbServiceRequest
            {
                Deadline = deadline,
                Cash = cash
            };

            var result = handler.Handle(command, CancellationToken.None).Result;

            Assert.Equal(expectedValue, result.GrossResult);

        }

        [Theory]
        [InlineData(100, 6, 104.63)]
        [InlineData(100, 8, 106.44)]
        [InlineData(100, 12, 109.85)]
        [InlineData(100, 18, 115.69)]
        [InlineData(100, 24, 121.56)]
        [InlineData(100, 26, 124.31)]
        public void Should_return_liquid_result(decimal cash, int deadline, decimal expectedValue)
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