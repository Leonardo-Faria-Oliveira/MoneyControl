using Bogus;
using MoneyControl.Communication.Enums;
using MoneyControl.Communication.Requests;

namespace CommonTestUtilities.Requests
{
    public class RequestRegisterExpenseJsonBuilder
    {

        public static RequestRegisterExpenseJson Build()
        {

            var faker = new Faker();
            return new RequestRegisterExpenseJson
            {
                Title = faker.Commerce.ProductName(),
                Amount = faker.Random.Decimal(min:1, max:1000),
                Date = faker.Date.Past(),
                Description = faker.Commerce.ProductDescription(),
                Type = faker.PickRandom<PaymentType>()
            };

        }

    }
}
