using Entities = Cdb.Domain.Entities;
using Domain.Validators;

namespace Domain.Tests
{
    public class CdbTest
    {
        [Fact]
        public void Given_a_deadline_less_or_equal_to_one_should_return_false()
        {
            var cdb = new Entities.Cdb(1000, 1);

            var validator = new CdbValidator();
            var result = validator.Validate(cdb);
            Assert.False(result.IsValid);
        }

        [Fact]
        public void Given_a_deadline_more_then_one_should_return_true()
        {
            var cdb = new Entities.Cdb(1000, 2);

            var validator = new CdbValidator();
            var result = validator.Validate(cdb);
            Assert.True(result.IsValid);
        }

        [Fact]
        public void Given_a_cash_less_or_equal_to_zero_should_return_false()
        {
            var cdb = new Entities.Cdb(0, 2);

            var validator = new CdbValidator();
            var result = validator.Validate(cdb);
            Assert.False(result.IsValid);
        }

        [Fact]
        public void Given_a_cash_more_then_zero_should_return_true()
        {
            var cdb = new Entities.Cdb(1, 2);

            var validator = new CdbValidator();
            var result = validator.Validate(cdb);
            Assert.True(result.IsValid);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        public void CalculateTax_Given_a_deadline_less_or_equal_to_six_should_return_0_225M(int deadline)
        {
            var tax = Entities.Cdb.CalculateTax(deadline);
            Assert.Equal(0.225M, tax);
        }

        [Theory]
        [InlineData(7)]
        [InlineData(8)]
        [InlineData(9)]
        [InlineData(10)]
        [InlineData(11)]
        [InlineData(12)]
        public void CalculateTax_Given_a_deadline_less_or_equal_to_twelve_should_return_0_20M(int deadline)
        {
            var tax = Entities.Cdb.CalculateTax(deadline);
            Assert.Equal(0.20M, tax);
        }

        [Theory]
        [InlineData(13)]
        [InlineData(14)]
        [InlineData(15)]
        [InlineData(16)]
        [InlineData(17)]
        [InlineData(18)]
        [InlineData(19)]
        [InlineData(20)]
        [InlineData(21)]
        [InlineData(22)]
        [InlineData(23)]
        [InlineData(24)]
        public void CalculateTax_Given_a_deadline_less_or_equal_to_twentyfour_should_return_0_175M(int deadline)
        {
            var tax = Entities.Cdb.CalculateTax(deadline);
            Assert.Equal(0.175M, tax);
        }

        [Theory]
        [InlineData(25)]
        [InlineData(26)]
        public void CalculateTax_Given_a_deadline_more_then_twentyfour_should_return_0_15M(int deadline)
        {
            var tax = Entities.Cdb.CalculateTax(deadline);
            Assert.Equal(0.15M, tax);
        }

        [Theory]
        [InlineData(100, 6, 105.98)]
        [InlineData(100, 5, 104.96)]
        [InlineData(100, 4, 103.95)]
        public void CalculateGrossIncome_Given_a_cash_and_deadline_should_return_gross_income(decimal cash, int deadline, decimal expected)
        {
            var grossIncome = Entities.Cdb.CalculateGrossIncome(cash, deadline);
            Assert.Equal(expected, grossIncome);
        }


        [Theory]
        [InlineData(100, 6, 104.63)]
        [InlineData(100, 4, 103.06)]
        public void CalculateLiquidIncome_Given_a_cash_and_deadline_should_return_liquid_income(decimal cash, int deadline, decimal expected)
        {
            var liquidIncome = Entities.Cdb.CalculateLiquidIncome(cash, deadline);
            Assert.Equal(expected, liquidIncome);
        }
    }
}