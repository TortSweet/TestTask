GetData();

///Getting input data
static void GetData()
{
    Console.WriteLine("Enter the loan amount");
    var amount = decimal.Parse(Console.ReadLine()!);

    Console.WriteLine("Enter the loan term (months)");
    var months = int.Parse(Console.ReadLine()!);

    Console.WriteLine("Enter the % loan rate");
    var rate = double.Parse(Console.ReadLine()!);

    Console.WriteLine("Enter the agreement date");
    var agreementDate = DateTime.Parse(Console.ReadLine()!);

    //Call the method to calculate payments
    PaymentCalculate(amount, rate, months, agreementDate);
}

static void PaymentCalculate(decimal credit, double rate, int month, DateTime agreementDate)
{
    #region Data validation
    if (credit <= 0)
    {
        throw new ArgumentException("Amount can't be equal or less than zero", nameof(credit));
    }
    if (rate <= 0)
    {
        throw new ArgumentException("Amount can't be equal or less than zero", nameof(credit));
    }
    if (month <= 0)
    {
        throw new ArgumentException("Amount can't be equal or less than zero", nameof(credit));
    }
    if (agreementDate < DateTime.Now)
    {
        throw new ArgumentException("The date cannot be earlier than the current date", nameof(credit));
    }
    #endregion
    Console.WriteLine("*************The monthly payments will be as follows: ");

    //Initialize additional variables for calculations
    double monthPayment, rateMonth, monthInterest, creditBody;
    var creditCopy = credit;
    var dateCopy = agreementDate;

    Console.WriteLine("Month" + "\t\t" + "Date" + "\t\t\t" + "Payment: " + "\t\t" + "Debt: " + "\t\t" + "Interest: " + "\t\t" + "Residue: ");
    //Calculate monthly rate
    rateMonth = rate / 100 / 12;
    //Calculate monthly payment
    monthPayment = (double)(credit * (decimal)(rateMonth + (rateMonth / (Math.Pow(1 + rateMonth, month) - 1))));

    //Calculate month interest and call method to output data
    for (var j = 0; j < month; j++)
    {
        monthInterest = (double)credit * rateMonth;

        credit -= (decimal)(monthPayment - monthInterest);
        creditBody = monthPayment - monthInterest;

        PrintData(j + 1, creditCopy > (decimal)monthPayment ? monthPayment : creditBody, creditBody, monthInterest,
            credit, dateCopy.AddMonths(j));
    }
}
//Output the table of monthly payments 
static void PrintData(int monthNum, double monthPayment, double creditBody, double monthInterest, decimal credit, DateTime agreementDate)
{
    Console.WriteLine("{0}" + "\t\t" + "{1}" + "\t\t" + "{2}" + "\t\t" + "{3}" + "\t\t" + "{4}" + "\t\t" + "{5}",
        monthNum, agreementDate.ToShortDateString(), Math.Round(monthPayment, 2), Math.Round(creditBody, 2), Math.Round(monthInterest, 2), Math.Round(credit, 2));
}