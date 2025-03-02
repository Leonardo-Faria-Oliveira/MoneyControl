namespace MoneyControl.Communication.Responses
{
    public class ResponseExpensesJson
    {

        public ICollection<ResponseShortExpenseJson> Expenses { get; set; } = [];

    }
}
