namespace Ucu.Poo.RoleplayGame;

public class Sorcerer : Character
{
    public SpellsBook SpellsBook { get; set; }

    public Sorcerer(string nombre, List<Item> items, double vida)
        : base(nombre, items, vida)
    {
      
    }
    //Se sobreescribio el metodo para permitir que el mago pueda usar cualquier item, sea magico o no.
    public override void AgregarItem(Item item)
    {
        Items.Add(item);
    }
}
