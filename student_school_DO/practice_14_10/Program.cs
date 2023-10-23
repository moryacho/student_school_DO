// See https://aka.ms/new-console-template for more information

//static string FooBar(int num)
//{
//    string res = "";
//    if (num % 3 == 0)
//    {
//        res += "foo";
//    }
//    if (num % 5 == 0)
//    {
//        res += "bar";
//    }

//    return res;
//}


//Console.Write("Input final number: ");
//int end = int.Parse(Console.ReadLine());
//for (int i = 1; i <= end; i++)
//{
//    Console.WriteLine(i + " " + FooBar(i));   
//}
//Console.ReadLine();

// функция, которая заменит все числа, не равные 0, на 1

static int[][] RemakeArray(int[][] array)
{   
    for (int x = 0; x < array.Length; x++)
    {
        for (int y = 0; y < array[x].Length; y++)
        {
            if (array[x][y] != 0)
            {
                array[x][y] = 1;
            }
        }
    }
    

    return array;
}



//int[] array = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

var array = new int[3][] { new int[] { 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0 }, new int[] { 0, 0, 0, 1 } };
var array2 = RemakeArray(array);


foreach (int[] line in array2)
{
    Console.WriteLine(string.Join(" ", line));
}


Console.ReadLine();