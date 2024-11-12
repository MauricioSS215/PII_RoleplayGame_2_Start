namespace Ucu.Poo.RoleplayGame;

public class Necromancer : Enemies
{
    public Necromancer() : base(nombre: "Quan Chi", items: new List<Item> 
            { 
                new ItemDeAtaque("Espada de Almas", ataque: 45), 
                new ItemDeDefensa("Escudo de Sangre Carmesi", defensa: 15) 
            }, vida: 50, vp: 3) // Este enemigo da 3 puntos de victoria al ser derrotado
    {
    }

    public override void GetStats()
    {
        base.GetStats();
        Console.WriteLine($"Este enemigo es un {Nombre}, y ofrece {VP} puntos de victoria al ser derrotado.");
    }
}
