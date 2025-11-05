
List<string> Weapon_names_prefix = new List<string> { "Проклятый", "Устрашающий", "Золотой", "Ненасытный", "Святой", "Нечестивый", "Старый" };
List<string> Weapon_names = new List<string> { "Меч", "Двуручный меч", "Арбалет", "Лук", "Кинжал", "Боевой топор" };
List<string> Weapon_names_suffix = new List<string> { "Лича", "Павшего воина", "Дракона", "Из чешуи дракона", "Из мифрила", "Крестоносца" };
List<string> Armor_names = new List<string> { "Доспех мертвеца", "Доспех крестоносца", "Доспех лича", "Латный доспех", "Доспех из чешуи дракона", "Деревянный доспех" };

Random random = new Random();

Console.WriteLine("================= D&D: Подземелья и подземелья =================");
Console.WriteLine("1. Начать игру.\n" +
        "2. Выход.");
int input = IntInput();
input = Choice(input, 2);
if (input == 1)
{
    Hero Player = HeroCreate();
    Console.WriteLine();
    int rounds_till_boss = 10;
    bool isboss = false;
    while (Player.HP > 0)
    {
        rounds_till_boss--;
        if (rounds_till_boss == 0)
        {
            isboss = true;
            rounds_till_boss = 10;
        }
        NextRound(Player, isboss);
    }
}

Hero HeroCreate()
{
    Console.Write("Кто ты, о Странник?\nВы: ");
    string hero_name = Console.ReadLine();
    if (hero_name == null)
    {
        hero_name = "Странник";
        Console.WriteLine("Никак? Значит, будешь просто Странник.");
    }
    Console.WriteLine($"Здравствуй, {hero_name}!");

    Console.WriteLine($"{hero_name}, впереди тебя ждут тяжёлые испытания. Возьми это.");
    Weapon start_weapon = new Weapon("Ржавый меч", 10);
    Armor start_armor = new Armor("Старые доспехи", 70);
    Console.WriteLine("Получено:");
    start_weapon.WeaponInfo();
    start_armor.ArmorInfo();
    Hero Player = new Hero(hero_name, 100, start_weapon, start_armor);
    return Player;
}


void NextRound(Hero Player, bool isboss)
{
    int turns = 1;
    if (isboss == false)
    {
        int round = random.Next(0, 2);
        if (round == 0)
        {
            Console.WriteLine("Вы наткнулись на противника!");
            var newenemy = NewEnemy.RandomEnemy();
            Console.WriteLine("Бой!");
            while (newenemy.HP > 0 && Player.HP > 0)
            {
                Console.WriteLine("=== === === ===");
                Console.WriteLine($"Ход {turns}");
                turns++;
                Fight(Player, newenemy);
                Console.WriteLine("=== === === ===\n");
            }
            if (newenemy.HP <= 0)
            {
                Console.WriteLine("___ ___ ___ Победа! ___ ___ ___");
            }
            else
            {
                Console.WriteLine("___ ___ ___ Вы проиграли! ___ ___ ___");
            }
        }
        else
        {
            Console.WriteLine("Вы наткнулись на сундук!");
            Loot(Player);
        }
    }
    else
    {
        Console.WriteLine("Вы наткнулись на Босса!");
        var newboss = NewBoss.RandomBoss();
        Console.WriteLine("Бой!");
        while (newboss.HP > 0 && Player.HP > 0)
        {
            Console.WriteLine("=== === === ===");
            Console.WriteLine($"Ход {turns}");
            turns++;
            Fight(Player, newboss);
            Console.WriteLine("=== === === ===");
        }
    }
}

void Fight(Hero Player, Enemy enemy)
{
    Console.WriteLine();

    enemy.EnemyInfo();
    Console.WriteLine();

    Player.HeroInfo();
    Console.WriteLine();
    Console.WriteLine("Ваш ход:\n" +
        "1. Атаковать.\n" +
        "2. Защищаться.");

    int action = IntInput();
    bool def = false;
    bool dodge = false;
    Choice(action, 2);
    if (action == 1)
    {
        enemy.GetDamage(Player.Weapon.ATK);
    }
    else
    {
        def = true;
        if (random.NextDouble() > 1 - 0.4)
        {
            dodge = true;
        }
    }

    Console.WriteLine();

    if (enemy.HP > 0)
    {
        Console.WriteLine("Ход противника: ");
        enemy.Attack(Player, def, dodge);
    }
}

void Loot(Hero Player)
{
    Random random = new Random();
    int loot = random.Next(1, 4);
    switch (loot)
    {
        case 1:
            Console.WriteLine("Вы нашли оружие!");
            Weapon new_weapon = new Weapon((Weapon_names_prefix[random.Next(0, 7)] + " " + Weapon_names[random.Next(0, 6)] + " " + Weapon_names_suffix[random.Next(0, 6)]), random.Next(10, 21));
            Player.ChangeWeapon(new_weapon);
            break;
        case 2:
            Console.WriteLine("Вы нашли броню!");
            Armor new_armor = new Armor(Armor_names[random.Next(0, 6)], random.Next(70, 100));
            Player.ChangeArmor(new_armor);
            break;
        case 3:
            Console.WriteLine("Вы нашли зелье лечения!");
            Player.Heal();
            break;
    }
}
int Choice(int choice, int max)
{
    while (choice > max || choice <= 0)
    {
        Console.WriteLine("Нет такого выбора!");
        Console.Write("Выбор: ");
        choice = IntInput();
    }
    return choice;
}

int IntInput()
{
    if (int.TryParse(Console.ReadLine(), out int output))
    {
        return output;
    }
    else
    {
        Console.WriteLine("Нет такого выбора!");
        Console.Write("Выбор: ");
        return IntInput();
    }
}

class NewEnemy
{
    public static Enemy RandomEnemy()
    {
        Random random = new Random();
        switch (random.Next(1, 4))
        {
            case 1:
                return Gob();
                break;
            case 2:
                return Sek();
                break;
            case 3:
                return Mag();
                break;
            default: return Sek();
        }
    }
    public static Enemy Gob()
    {
        return new Goblin(65, 6, 1, Race.Goblin, 0.35);
    }
    public static Enemy Sek()
    {
        return new Sekleton(50, 5, 1.2, Race.Sekleton, true);
    }
    public static Enemy Mag()
    {
        return new Mage(60, 7, 0.8, Race.Mage, 0.4);
    }

}

class NewBoss
{
    public static Enemy RandomBoss()
    {
        Random random = new Random();
        switch (random.Next(1, 5))
        {
            case 1:
                return Gorlanov();
                break;
            case 2:
                return Covalevski();
                break;
            case 3:
                return Arhcimage_CPP();
                break;
            case 4:
                return Pestov_CMM();
            default: return Pestov_CMM();
        }
    }
    public static Enemy Gorlanov()
    {
        return new Goblin(65 * 2, Math.Round(6 * 1.5), 1.2, Race.Goblin, 0.35 + 0.1);
    }
    public static Enemy Covalevski()
    {
        return new Sekleton(Math.Round(50 * 2.5), Math.Round(5 * 1.3), 1.4, Race.Sekleton, true);
    }
    public static Enemy Arhcimage_CPP()
    {
        return new Mage(Math.Round(60 * 1.8), Math.Round(7 * 1.6), 0.8 * 1.1, Race.Mage, 0.4 + 0.1);
    }

    public static Enemy Pestov_CMM()
    {
        return new Pestov(Math.Round(50 * 1.3), Math.Round(5 * 1.8), 1.4 * 0.6, Race.Sekleton, true, 0.4 + 0.15);
    }

}


class Weapon
{
    public string Name { get; private set; }
    public int ATK { get; private set; }

    public Weapon(string name, int atk)
    {
        Name = name;
        ATK = atk;
    }

    public void WeaponInfo()
    {
        Console.WriteLine($"Оружие:\n" +
            $"Название: {Name}\n" +
            $"Урон: {ATK}");
    }
}


class Armor
{
    public string Name { get; private set; }
    public double DEF { get; private set; }

    public Armor(string name, int def)
    {
        Name = name;
        DEF = def;
    }

    public void ArmorInfo()
    {
        Console.WriteLine($"Доспехи:\n" +
            $"Название: {Name}\n" +
            $"Защита: {DEF}");
    }

}


class Hero
{
    public string Name { get; private set; }
    public double HP { get; private set; }
    public Weapon Weapon { get; private set; }
    public Armor Armor { get; private set; }

    public Hero(string name, double hp, Weapon weapon, Armor armor)
    {
        Name = name;
        HP = hp;
        Weapon = weapon;
        Armor = armor;
    }

    public void HeroInfo()
    {
        Console.WriteLine($"{Name}:\n" +
            $"ОЗ: {HP}");
    }

    public void GetDamage(double Dmg)
    {
        Console.WriteLine($"Вам нанесли {Math.Round(Dmg)} урона");
        HP = Math.Round(HP - Dmg);
    }

    public void Heal()
    {
        HP = 100;
    }

    public void ChangeWeapon(Weapon new_weapon)
    {
        Console.WriteLine("Вы нашли:");
        new_weapon.WeaponInfo();
        Console.WriteLine("Ваше оружие:");
        Weapon.WeaponInfo();
        Console.WriteLine("Заменить оружие?\n" +
            "1. Да.\n" +
            "2. Нет.");
        string change = Console.ReadLine();
        while (change != "1" && change != "2")
        {
            Console.WriteLine("Неправильный ввод!");
            Console.Write("Ввод: ");
            change = Console.ReadLine();
        }
        if (change == "1")
        {
            Weapon = new_weapon;
        }
    }

    public void ChangeArmor(Armor new_armor)
    {
        Console.WriteLine("Вы нашли:");
        new_armor.ArmorInfo();
        Console.WriteLine("Ваша броня:");
        Armor.ArmorInfo();
        Console.WriteLine("Заменить броню?\n" +
            "1. Да.\n" +
            "2. Нет.");
        string change = Console.ReadLine();
        while (change != "1" && change != "2")
        {
            Console.WriteLine("Неправильный ввод!");
            Console.Write("Ввод: ");
            change = Console.ReadLine();
        }
        if (change == "1")
        {
            Armor = new_armor;
        }
    }

}

enum Race
{
    Goblin = 1,
    Sekleton,
    Mage
}

class Enemy
{
    public double HP { get; private set; }
    public double ATK { get; private set; }
    public double DEF { get; private set; }
    public Race Race { get; private set; }


    public Enemy(double hp, double atk, double def, Race race)
    {
        HP = hp;
        ATK = atk;
        DEF = def;
        Race = race;
    }

    public void EnemyInfo()
    {
        Console.WriteLine($"{Race}:\n" +
            $"ОЗ: {HP}");
    }

    public virtual void GetDamage(double Dmg)
    {
        Console.WriteLine($"{Race} получил {Math.Round(Dmg / DEF)} урона.");
        HP = HP - Math.Round(Dmg / DEF);
    }

    public virtual void Attack(Hero Player, bool def, bool dodge)
    {
        if (dodge == false)
        {
            if (def == true)
            {
                Player.GetDamage(ATK / Player.Armor.DEF);
            }
            else { Player.GetDamage(ATK); }
        }
        else
        {
            Console.WriteLine("Вы успешно уклонились от атаки");
        }
    }

}

class Goblin : Enemy
{
    public double Crit;

    public Goblin(double hp, double atk, double def, Race race, double crit)
        : base(hp, atk, def, race)
    {
        Crit = crit;
    }

    public override void Attack(Hero Player, bool def, bool dodge)
    {
        Random rand = new Random();
        if (dodge == false)
        {
            if (def = true)
            {
                if (rand.NextDouble() > 1 - Crit)
                {
                    Console.WriteLine("Крит!");
                    Player.GetDamage(ATK * 2 * (Player.Armor.DEF / 100));
                }
                else
                {
                    Player.GetDamage(ATK * (Player.Armor.DEF / 100));
                }
            }
            else
            {
                if (rand.NextDouble() > 1 - Crit)
                {
                    Player.GetDamage(ATK * 2);
                }
                else
                {
                    Player.GetDamage(ATK);
                }
            }
        }
        else
        {
            Console.WriteLine("Вы успешно уклонились от атаки!");
        }
    }
}

class Sekleton : Enemy
{
    public bool IgnoreDEF { get; private set; }
    public Sekleton(double hp, double atk, double def, Race race, bool ignoredef)
        : base(hp, atk, def, race)
    {
        IgnoreDEF = true;
    }

    public override void Attack(Hero Player, bool def, bool dodge)
    {
        if (dodge == false)
        {
            Player.GetDamage(ATK);
        }
        else
        {
            Console.WriteLine("Вы успешно уклонились от атаки");
        }
    }
}


class Mage : Enemy
{
    public double Freeze;

    public Mage(double hp, double atk, double def, Race race, double freeze)
        : base(hp, atk, def, race)
    {
        Freeze = freeze;
    }

    public override void Attack(Hero Player, bool def, bool dodge)
    {
        Random rand = new Random();
        if (dodge == false)
        {
            if (def == true)
            {
                Player.GetDamage(ATK * (Player.Armor.DEF / 100));
            }
            else
            {
                Player.GetDamage(ATK);
            }

            if (rand.NextDouble() > 1 - Freeze)
            {
                Console.WriteLine("Вас заморозили! Вы пропускаете ход.");
                Attack(Player, true, false);
            }
        }
        else
        {
            Console.WriteLine("Вы успешно уклонились от атаки");
        }
    }

}

class VVG : Goblin
{
    public VVG(double hp, double atk, double def, Race race, double crit)
        : base(hp, atk, def, race, crit)
    {
        Crit = crit + 10;
    }
}

class Coval : Sekleton
{
    public Coval(double hp, double atk, double def, Race race, bool ignoredef)
        : base(hp, atk, def, race, ignoredef)
    {
    }
}

class Arhcimage : Mage
{
    public Arhcimage(double hp, double atk, double def, Race race, double freeze)
        : base(hp, atk, def, race, freeze)
    {
        Freeze = freeze;
    }
}

class Pestov : Sekleton
{
    public double Freeze { get; private set; }
    public Pestov(double hp, double atk, double def, Race race, bool ignoredef, double freeze)
        : base(hp, atk, def, race, ignoredef)
    {
        Freeze = freeze;
    }

    public override void Attack(Hero Player, bool def, bool dodge)
    {
        Random rand = new Random();
        if (dodge == false)
        {
            Player.GetDamage(ATK);
            if (rand.NextDouble() > 1 - Freeze)
            {
                Console.WriteLine("Вас заморозили! Вы пропускаете ход.");
                Attack(Player, true, false);
            }
        }
        else
        {
            Console.WriteLine("Вы успешно уклонились от атаки");
        }
    }
}