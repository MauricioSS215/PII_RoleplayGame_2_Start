namespace Ucu.Poo.RoleplayGame;

public class Heroes:Character
{
    public int VP;

    public Heroes(string nombre, List<Item> items, double vida,int vp) : base(nombre, items, vida)
    {
        this.VP = vp;
    }

}