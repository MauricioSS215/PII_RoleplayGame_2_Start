namespace Ucu.Poo.RoleplayGame;

public class Enemies:Character
{
    public int VP;

    public Enemies(string nombre, List<Item> items, double vida, int vp) : base(nombre, items, vida)
    {
        this.VP = vp;
    }
}