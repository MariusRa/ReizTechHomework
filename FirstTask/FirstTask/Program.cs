// Calculate angles between arrows

static decimal CountAngle(int hour, int minutes)
{
    var hourAngle = (hour * 360 / 12 + (minutes / 60m) * 360 / 12m); // each hour mark is 30 degrees. 
    var minutesAngle = 360 / 60 * minutes; // each minute mark is 6 degrees.

    var angleBetween = Decimal.Round(Math.Abs(hourAngle - minutesAngle), 2);

    return angleBetween;
}

//Declare and validate inputs 

int hour;
int minutes;

Console.WriteLine("Enter hour");
    try
    {
        hour = Convert.ToInt32(Console.ReadLine());
        if (hour < 0 || hour > 12)
        {
            Console.WriteLine("Wrong input. Reenter hour!");
            hour = Convert.ToInt32(Console.ReadLine());
        }
    }
    catch (FormatException)
    {
        Console.WriteLine("Wrong input. Reenter hour!");
        hour = Convert.ToInt32(Console.ReadLine());
    }
  
Console.WriteLine("Enter minutes");
    try
    {
        minutes = Convert.ToInt32(Console.ReadLine());
        if (minutes < 0 || minutes > 60)
        {
            Console.WriteLine("Wrong input. Reenter minutes!");
            minutes = Convert.ToInt32(Console.ReadLine());
        }
    }
    catch (FormatException)
    {
        Console.WriteLine("Wrong input. Reenter minutes!");
        minutes = Convert.ToInt32(Console.ReadLine());
    }
    
        if (hour == 12)
        {
            hour = 0;
        }

        if (minutes == 60)
        {
            minutes = 0;
            hour += 1;
            if (hour > 12)
            {
                hour = hour - 12;
            }
        }

Console.WriteLine($"Entered time is {hour}:{minutes}.");
Console.WriteLine($"Angle between arrows are: {CountAngle(hour, minutes)} degrees.");
