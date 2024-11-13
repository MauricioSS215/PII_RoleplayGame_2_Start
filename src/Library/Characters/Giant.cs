using System.Threading.Channels;

namespace Ucu.Poo.RoleplayGame;

public class Giant:Enemies
{
    public Giant() : base(nombre: "Tifón", items: new List<Item>
        {
            new ItemDeAtaque("Manopla Gigante", 60),
            new ItemDeDefensa("Casco de Hierro", 10)
        }, vida: 100, vp: 5)
    {
    }

    public override void GetStats()
    {
        base.GetStats();
        Console.WriteLine($"Este enemigo es un {Nombre} y ofrece {VP} puntos de victoria al ser derrotado");
    }
}