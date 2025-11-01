using System.Security.Cryptography.X509Certificates;

Random random = new Random();

Console.WriteLine("================= D&D: Подземелья и подземелья =================");
Console.WriteLine("1. Начать игру.\n" +
        "2. Выход.");
int input = IntInput();
Choice(input, 2);
if (input == 1)
{
    NextRound();
}



void NextRound()
{
    int round = random.Next(0, 1);
    if (round == 0)
    {
        Console.WriteLine("Вы наткнулись на противника!");
        var newenemy = NewEnemy.RandomEnemy();
        Fight(newenemy);
    }
    else
    {
        Console.WriteLine("Вы наткнулись на сундук!");
        Loot();
    }

}

void Fight()
{
    while ()
}

void Choice(int choice, int max)
{
    while (choice > max || choice < 0)
    {
        Console.WriteLine("Нет такого выбора!");
        Console.Write("Выбор: ");
        choice = IntInput();
    }
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


class Weapon
{
    public string Name { get; private set; }
    public int ATK { get; private set; }
    public double Chance { get; private set; }

    public Weapon(string name, int atk, double chance)
    {
        Name = name;
        ATK = atk;
        Chance = chance;
    }
}


class Armor
{
    public string Name { get; private set; }
    public double DEF { get; private set; }
    public double Chance { get; private set; }

    public Armor(string name, int def, double chance)
    {
        Name = name;
        DEF = def;
        Chance = chance;
    }
}


class Hero
{
    public string Name { get; private set; }
    public int HP { get; private set; }
    public Weapon Weapon { get; private set; }
    public Armor Armor { get; private set; }

    public Hero(string name, int hp, Weapon weapon, Armor armor)
    {
        Name = name;
        HP = hp;
        Weapon = weapon;
        Armor = armor;
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


    public Enemy (double hp, double atk, double def, Race race)
    {
        HP = hp;
        ATK = atk;
        DEF = def;
        Race = race;
    }
    
    public void EnemyInfo()
    {
        Console.WriteLine($"Противник: {Race}\n" +
            $"Урон: {ATK}\n" +
            $"Защита: {DEF}\n" +
            $"ОЗ: {HP}");
    }

}

class Goblin : Enemy
{
    public double Crit;
    
    public Goblin(double hp, double atk, double def, Race race, double crit)
        :base(hp, atk, def, race)
    {
        Crit = crit;
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

}

class Mage : Enemy
{
    public double Freeze;

    public Mage(double hp, double atk, double def, Race race, double freeze)
        : base(hp, atk, def, race)
    {
        Freeze = freeze;
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
    public int Freeze { get; private set; } = 55;
    public Pestov(double hp, double atk, double def, Race race, bool ignoredef, int freeze) 
        : base(hp, atk, def, race, ignoredef)
    {
        Freeze = freeze;
    }
}