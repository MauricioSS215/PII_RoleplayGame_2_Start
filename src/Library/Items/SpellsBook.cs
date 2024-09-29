namespace Ucu.Poo.RoleplayGame;

public class SpellsBook
{
    public List<Spell> Spells { get; set; }
    
    public int AttackValue
    {
        get
        {
            int value = 0;
            foreach (Spell spell in this.Spells)
            {
                value += spell.AttackValue;
            }
            return value;
        }
    }

    public int DefenseValue
    {
        get
        {
            int value = 0;
            foreach (Spell spell in this.Spells)
            {
                value += spell.DefenseValue;
            }
            return value;
        }
    }

    public SpellsBook()
    {
        Spells = new List<Spell>();
    }

    public void AddSpell(Spell spell)
    {
        Spells.Add(spell);
    }
}
