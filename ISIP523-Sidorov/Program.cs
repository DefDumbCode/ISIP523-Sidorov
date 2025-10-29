


using System.Runtime.ConstrainedExecution;
using System.Runtime.Serialization;

enum Race
{
    Goblin = 1,
    Sekleton,
    Mage
}

class Enemy
{
    public double HP;
    public double ATK;
    public double DEF;
    public Race Race { get; private set; }

    public bool IgnoreDEF = false;

    public Enemy (double hp, double atk, double def, Race race, bool ingnoredef)
    {
        HP = hp;
        ATK = atk;
        DEF = def;
        Race = race;
        IgnoreDEF = ingnoredef;
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
    public int Crit;
    
    public Goblin(double hp, double atk, double def, Race race, bool ignoredef, int crit)
        :base(hp, atk, def, race, ignoredef)
    {
        Crit = crit;
    }
}

class Sekleton : Enemy
{

    public Sekleton(double hp, double atk, double def, Race race, bool ignoredef)
        : base(hp, atk, def, race, ignoredef)
    {
        IgnoreDEF = true;
    }

}

class Mage : Enemy
{
    public int Freeze = 40;

    public Mage(double hp, double atk, double def, Race race, bool ignoredef, int freeze)
        : base(hp, atk, def, race, ignoredef)
    {
        Freeze = freeze;
    }

}

class VVG : Goblin
{
    public VVG(double hp, double atk, double def, Race race, bool ignoredef, int crit) 
        : base(hp, atk, def, race, ignoredef, crit)
    {
        HP = Math.Round(hp * 2);
        ATK = Math.Round(atk * 1.5);
        DEF = Math.Round(def * 1.2);
        Crit = crit + 10;
    }
}

class Coval : Sekleton
{
    public Coval(double hp, double atk, double def, Race race, bool ignoredef)
        : base(hp, atk, def, race, ignoredef)
    {
        HP = Math.Round(hp * 2.5);
        ATK = Math.Round(atk * 1.3);
        DEF = Math.Round(def * 1.4);
    }
}

class Arhcimage : Mage
{
    public Arhcimage(double hp, double atk, double def, Race race, bool ignoredef, int freeze)
        : base(hp, atk, def, race, ignoredef, freeze)
    {
        HP = Math.Round(hp * 2.5);
        ATK = Math.Round(atk * 1.6);
        DEF = Math.Round(def * 1.1);
        Freeze = freeze + 10;
    }
}

class Pestov : Sekleton
{
    int Freeze = 55;
    public Pestov(double hp, double atk, double def, Race race, bool ignoredef, int freeze) 
        : base(hp, atk, def, race, ignoredef)
    {
        HP = Math.Round(hp * 1.3);
        ATK = Math.Round(atk * 1.8);
        DEF = Math.Round(def * 0.6);
        Freeze = freeze;
    }
}