for(int i = 1; i < 10; i++)
{
    for(int j = 1; j < 10; j++)
        Console.Write($"{j} * {i} = {j * i} \t"); // следующий консольный вывод будет не в этом блоке, поэтому можно не писать Console.WriteLine();
}
