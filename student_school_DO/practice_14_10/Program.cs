// See https://aka.ms/new-console-template for more information

static string FooBar(int num)
{
    string res = "";
    if (num % 3 == 0)
    {
        res += "foo";
    }
    if (num % 5 == 0)
    {
        res += "bar";
    }

    return res;
}


Console.Write("Input final number: ");
int end = int.Parse(Console.ReadLine());
for (int i = 1; i <= end; i++)
{
    Console.WriteLine(i + " " + FooBar(i));   
}
Console.ReadLine();