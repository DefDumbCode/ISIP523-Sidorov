
Console.WriteLine("Введите кол-во операций за день: ");
int n;
int.TryParse(Console.ReadLine(), out n);

string[] operations = new string[n];
int[] cost = new int[n];

for (int i = 0; i < n; i++)
{
    string[] input = Console.ReadLine().Split(new char[] {';'}, StringSplitOptions.RemoveEmptyEntries);
    operations[i] = input[0];
    int.TryParse(input[1], out cost[i]);
}

Console.WriteLine("Выберите операцию:\n" +
    "1. Вывод данных\n" +
    "2. Статистика\n" +
    "3. Сортировка\n" +
    "4. Конвертация валюты\n" +

    "5. Поиск по названию\n" +
    "0. Выход");
string op = Console.ReadLine();


switch (op)
{
    case "0":
        break;


    case "1":
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"{operations[i]}; {cost[i]}");
        }
        break;


    case "2":
        Console.WriteLine($"Средняя сумма затрат: {cost.Average()}");
        Console.WriteLine($"Максимальная сумма операции: {cost.Max()}");
        Console.WriteLine($"Минимальная сумма операции: {cost.Min()}");
        Console.WriteLine($"Общая сумма затрат: {cost.Sum()}");
        break;


    case "3":
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (cost[j] > cost[j + 1])
                {
                    int t_cost = cost[j];
                    string t_op = operations[j];
                    cost[j] = cost[j + 1];
                    operations[j] = operations[j + 1];
                    cost[j + 1] = t_cost;
                    operations[j + 1] = t_op;
                } 
            }
        }
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"{operations[i]}; {cost[i]}");
        }
        break;


    case "4":
        Console.WriteLine("Выберите курс валют:\n" +
            "1.Евро\n" +
            "2.Бел. руб.\n" +
            "3.Доллар\n");
        string currency = Console.ReadLine();
        double course;
        double[] cost_cur = new double[n];
        switch (currency)
        {
            case "1":
                course = 0.010262;
                for (int i = 0; i < n; i++)
                {
                    cost_cur[i] = cost[i] * course;
                }
                break;
            case "2":
                course = 0.012038;
                for (int i = 0; i < n; i++)
                {
                    cost_cur[i] = cost[i] * course;
                }
                break;
            case"3":
                course = 0.036268;
                for (int i = 0; i < n; i++)
                {
                    cost_cur[i] = cost[i] * course;
                }
                break;
            default: 
                Console.WriteLine("Неправильный курс");
                break;
        }
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"{operations[i]}; {cost_cur[i]}");
        }
        break;


    case "5":
        Console.Write("Поиск по наименованию операции:");
        string search = Console.ReadLine().ToLower();

        for (int item = 0; item < n; item++)
        {
            if (operations[item].ToLower().Contains(search))
            {
                Console.WriteLine($"{operations[item]}; {cost[item]}");
            }
        }
        break;


    default:
        break;
}

