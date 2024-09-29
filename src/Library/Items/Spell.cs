namespace Ucu.Poo.RoleplayGame;

public class Spell
{
    public string Name{ get; private set; }
    public int AttackValue { get; private set; }

    public int DefenseValue { get; private set; }

    public Spell(string name, int attack, int defense)
    {
        this.Name = name;
        this.AttackValue = attack;
        this.DefenseValue = defense;
    }
}
