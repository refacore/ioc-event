namespace Events.CSharpEvent;

public class CalculatorEventArgs
{
    public int Id { get; set; }
}

public class CSharpEventIllustrator
{
    public delegate void CalculatorEventHandler(object sender, CalculatorEventArgs eventArgs);
    public event CalculatorEventHandler? CalcEvent;

    public void DoACalc()
    {
        Console.WriteLine("Do something and event occurs");

        if (CalcEvent != null)
        {
            CalcEvent(this, new CalculatorEventArgs { Id = 2 });
        }
    }
}
