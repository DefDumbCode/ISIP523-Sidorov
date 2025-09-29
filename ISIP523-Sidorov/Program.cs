List<char> punct = new List<char>() { '.', ',', '!', '?', '"', '-', ':', ';' };
List<char> cons = new List<char>() { 'б', 'в', 'г', 'д', 'ж', 'з', 'й', 'к', 'л', 'м', 'н', 'п', 'р', 'с', 'т', 'ф', 'х', 'ц', 'ч', 'ш', 'щ' };
List<char> vowels = new List<char>() { 'а', 'е', 'ё', 'и', 'о', 'у', 'ы', 'э', 'ю', 'я' };
List<string> Texts = new List<string>();
List<Dictionary<char, int>> Stats = new List<Dictionary<char, int>>();

string input = "1";
while (input != "6")
{
    Console.WriteLine("\n/__________МЕНЮ___________/");
    Console.WriteLine("1. Добавить новый текст.");
    Console.WriteLine("2. Просмотр текста.");
    Console.WriteLine("3. Статистика по тексту.");
    Console.WriteLine("4. Выход.");
    input = Console.ReadLine();
    switch (input)
    {
        case "1":
            TextAdd();
            break;
        case "2":
            if (Texts.Count > 0)
            {
                TextView();
            }
            else
            {
                Console.WriteLine("Сначала введите текст!");
            }
            break;
        case "3":
            if (Texts.Count > 0)
            {
                TextStat();
            }
            else
            {
                Console.WriteLine("Сначала введите текст!");
            }
            break;
        case "4":
            break;
        default:
            Console.WriteLine("Неправильная команда!");
            break;
    }
}
void TextAdd()
{
    Console.WriteLine("Введите строку (не менее 100 символов):");
    string text = Console.ReadLine();
    while (text == null || text.Length < 100)
    {
        Console.WriteLine("Длина текста должна быть не менее 100 символов");
        text = Console.ReadLine();
    }
    Texts.Add(text);
    Console.WriteLine("Текст успешно добавлен");
}

void TextView()
{
    Console.Write("Введите ID текста: ");
    int id = int.Parse(Console.ReadLine()) - 1;
    while (id < 0 || id > Texts.Count - 1)
    {
        Console.WriteLine("Неправильный индекс!");
        Console.Write("Введите ID текста: ");
        id = int.Parse(Console.ReadLine()) - 1;
    }
    Console.WriteLine(Texts[id]);
}

void TextStat()
{
    Console.Write("Введите ID текста: ");
    int id = int.Parse(Console.ReadLine()) - 1;
    while (id < 0 || id > Texts.Count - 1)
    {
        Console.WriteLine("Неправильный индекс!");
        Console.Write("Введите ID текста: ");
        id = int.Parse(Console.ReadLine()) - 1;
    }
    Console.WriteLine("\n___СТАТИСТИКА___");
    string[] words = Texts[id].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

    Dictionary<char, int> stat = new Dictionary<char, int>()
    {
    { 'а', 0 }, { 'б', 0 }, { 'в', 0 },
    { 'г', 0 }, { 'д', 0 }, { 'е', 0 },
    { 'ё', 0 }, { 'ж', 0 }, { 'з', 0 },
    { 'и', 0 }, { 'й', 0 }, { 'к', 0 },
    { 'л', 0 }, { 'м', 0 }, { 'н', 0 },
    { 'о', 0 }, { 'п', 0 }, { 'р', 0 },
    { 'с', 0 }, { 'т', 0 }, { 'у', 0 },
    { 'ф', 0 }, { 'х', 0 }, { 'ц', 0 },
    { 'ч', 0 }, { 'ш', 0 }, { 'щ', 0 },
    { 'ъ', 0 }, { 'ы', 0 }, { 'ь', 0 },
    { 'э', 0 }, { 'ю', 0 }, { 'я', 0 },
    };


    for (int i = 0; i < words.Length; i++)
    {
        for (int j = 0; j < words[i].Length; j++)
        {
            if (punct.Contains(words[i][j]))
            {
                words[i] = words[i].Remove(j);
            }
        }
    }


    string shortest = words[0];
    for (int i = 1; i < words.Length; i++)
    {
        if (words[i].Length < shortest.Length && words[i] != "")
        {
            shortest = words[i];
        }
    }
    Console.WriteLine($"Самое короткое слово: {shortest}");

    string longest = words[0];
    for (int i = 0; i < words.Length - 1; i++)
    {
        if (words[i].Length > longest.Length)
        {
            longest = words[i];
        }
    }
    Console.WriteLine($"Самое длинное слово: {longest}");

    int sent = 0;
    foreach (char s in Texts[id])
    {
        if (s == '.' || s == '!' || s == '?')
        {
            sent++;
        }
    }
    Console.WriteLine($"Предложений в тексте: {sent}");


    int cons_count = 0;
    int volwes_count = 0;
    foreach (string word in words)
    {
        foreach (char s in word.ToLower())
        {
            if (cons.Contains(s))
            {
                cons_count++;
            }
            else if (vowels.Contains(s))
            {
                volwes_count++;
            }
            stat[s]++;
        }
    }
    Console.WriteLine($"Кол-во согласных в тексте: {cons_count}");
    Console.WriteLine($"Кол-во гласных в тексте: {volwes_count}");


    Console.WriteLine("___СТАТИСТИКА ПО БУКВАМ___");
    foreach (var (key, val) in stat)
    {
        double precent = Convert.ToDouble(val) / Texts[id].Length * 100;
        Console.WriteLine($"{key}: {val} ({Math.Round(precent, 2)}%)");
    }
    Stats.Add(stat);
}