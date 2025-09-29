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




