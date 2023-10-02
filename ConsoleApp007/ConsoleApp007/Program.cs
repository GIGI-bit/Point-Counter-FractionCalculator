using ConsoleApp007;
using Microsoft.VisualBasic;

  int Menu(params string[] strings)
{
    int index = 0;


    dynamic choice;
    while (true)
    {
        Console.Clear();
        for (int i = 0; i < strings.Length; i++)
        {
            if (index == i)
                Console.Write("->");
            Console.WriteLine(strings[i]);
        }
        choice = Console.ReadKey();
        if (index == 0 && choice.Key == ConsoleKey.UpArrow)
        {
            index = strings.Length - 1;
        }
        else if (choice.Key == ConsoleKey.UpArrow)
        {
            index--;
        }
        else if (index == strings.Length - 1 && choice.Key == ConsoleKey.DownArrow)
        {
            index = 0;
        }
        else if (choice.Key == ConsoleKey.DownArrow)
        {
            index++;
        }
        else if (choice.Key == ConsoleKey.Enter) return index;
    }

}
void Count()
{
    Console.Write("Enter min value: ");
    int min=Convert.ToInt32(Console.ReadLine());
    Console.Write("Enter max value: ");
    int max=Convert.ToInt32(Console.ReadLine());
    Counter counter = new(min, max);
    int index = 0;
    string[] strings = { "increment","", "decrement" };

    dynamic choice;
    while (true)
    {
        Console.Clear();
        for (int i = 0; i < strings.Length; i++)
        {
            if (index == i&&i!=1)
                Console.Write("->");
            if(i==1) { Console.WriteLine("  "+counter.getCurrent); continue; }
            Console.WriteLine(strings[i]);
        }
        choice = Console.ReadKey();
        if ((choice.Key == ConsoleKey.UpArrow && index == 0) ||(choice.Key == ConsoleKey.DownArrow))
        {
            index = strings.Length - 1; 
        }
        else if ((choice.Key == ConsoleKey.DownArrow &&  index == strings.Length - 1) || (choice.Key == ConsoleKey.UpArrow))
        {
            index = 0;
        }
        else if (choice.Key == ConsoleKey.Enter)
        {
            if (index == 0) counter.increment();
            else if (index == 2) counter.decrement();
        }
    }
}
 void Coordination()
{
    Console.WriteLine("Enter numbers between 0-10.");
    Console.Write("Enter x: ");
    int x = Convert.ToInt32(Console.ReadLine());
    Console.Write("Enter y: ");
    int y = Convert.ToInt32(Console.ReadLine());
    Point point = new Point(x, y);
    int[] arr = new int[10];
    for (global::System.Int32 i = 0; i < 10; i++)
    {
        Console.Write(i);
        for (global::System.Int32 j = 0; j <10; j++)
        {
            if (i == x && j == y) Console.Write("*");
            if (i==9) Console.Write(j+" ");
            else Console.Write("  ");
        }
        Console.WriteLine();
    }

}
void FractionCalculator()
{
    Console.WriteLine("Enter Numerator of the first fraction: ");
    int num_1=Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Enter Denumerator of the first fraction: ");
    int denum_1=Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Enter Numerator of the second fraction: ");
    int num_2=Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Enter Denumerator of the second fraction: ");
    int denum_2=Convert.ToInt32(Console.ReadLine());
    Fraction frac_1 = new(num_1, denum_1);
    Fraction frac_2=new(num_2, denum_2);
    Console.Clear();
    int index = Menu("Addition", "Subtraction", "Multiply", "Divide");
    if(index == 0)
    {
        Console.WriteLine(frac_1+" + "+frac_2+" = "+(frac_1+frac_2));
    }
    else if (index==1) Console.WriteLine(frac_1+" - "+frac_2+" = "+(frac_1-frac_2));
    else if(index==2) Console.WriteLine(frac_1+" * "+frac_2+" = "+( frac_1*frac_2));
    else if(index==3) Console.WriteLine(frac_1+" / "+frac_2+" = "+(frac_1/frac_2));
}


//int index = Menu("Point", "Counter", "Fraction Calculator");

//if (index == 0)
//{
//    Coordination();
//}
//else if (index == 1)
//{

//}
//else if (index == 2)
//{
//    FractionCalculator();

//}

Count();
