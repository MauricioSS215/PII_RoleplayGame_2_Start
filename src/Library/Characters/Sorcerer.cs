namespace Ucu.Poo.RoleplayGame;

public class Sorcerer : Heroes
{
    public SpellsBook SpellsBook { get; set; }
    private Baston? baston;
    public Baston? Baston
    {
        get { return baston; }
        set
        {
            if (value != null)
            {
                foreach (Item i in Items)
                {
                    i.Ataque *= 1.5;
                    i.Defensa *= 1.5;
                }
            }
            else if (baston != null)
            {
                foreach (Item i in Items)
                {
                    i.Ataque /= 1.5;
                    i.Defensa /= 1.5;
                }
            }
            baston = value; 
        }
    }

    public Sorcerer(string nombre, List<Item> items, double vida,SpellsBook spellbook, Baston? baston=null)
        : base(nombre, items, vida)
    {
        this.Baston = baston;
        this.SpellsBook = spellbook;
    }
    //Se sobreescribio el metodo para permitir que el mago pueda usar cualquier item, sea magico o no.
    public override void AgregarItem(Item item)
    {
        Items.Add(item);
    }

    public void AddBaston(Baston baston)
    {
        Baston = baston;
    }
}
