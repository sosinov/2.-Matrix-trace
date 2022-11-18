using MatrixTrace;

int GetInputInt() 
{
    int result = 0;
    do
    {
        string inputString = Console.ReadLine();
        bool inputIsInt = int.TryParse(inputString, out var intNumber);
        if (inputIsInt && intNumber > 0)
        {
            result = intNumber;
        }
        else
        {
            Console.WriteLine("Invalid data. Please input int number > 0.");
        }
    }
    while (result == 0);
    return result;
}

Console.WriteLine("Input columns number:");
int columns = GetInputInt();
Console.WriteLine("Input rows number:");
int rows = GetInputInt();

Matrix matrix1 = new Matrix(columns, rows);
matrix1.PrintMatrix();

Console.WriteLine("\nThe matrix trace = {0}", matrix1.SumMainDiagonal());
matrix1.EnhancedTask();

Console.ReadLine();