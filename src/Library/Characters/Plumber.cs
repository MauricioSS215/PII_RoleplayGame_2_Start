namespace Ucu.Poo.RoleplayGame;

public class Plumber : Enemies
{
    public Plumber() : base(nombre: "Ricardo", new List<Item>
    {
        new ItemDeAtaque("Llave Inglesa", ataque: 20),
        new ItemDeDefensa("Mameluco Resistente", defensa: 15)
    }, vida: 45, vp: 1) // Este enemigo da 1 punto de victoria al ser derrotado
    {
    }
    
    public override void GetStats()
    {
        base.GetStats();
        Console.WriteLine($"Este enemigo es un {Nombre}, y ofrece {VP} puntos de victoria al ser derrotado.");
    }
}
