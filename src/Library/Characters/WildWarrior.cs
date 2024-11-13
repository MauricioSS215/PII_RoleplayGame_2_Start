namespace Ucu.Poo.RoleplayGame;

public class WildWarrior : Enemies
{
    public WildWarrior() : base(nombre: "Alcoth", items: new List<Item>
            {
                new ItemDeAtaque("Hacha Brutal", ataque: 50),
                new ItemDeDefensa("Armadura de Hierro", defensa: 20)
            }, vida: 60, vp: 4) // Este enemigo da 4 puntos de victoria al ser derrotado
    {
    }
    
    public override void GetStats()
    {
        base.GetStats();
        Console.WriteLine($"Este enemigo es un {Nombre}, y ofrece {VP} puntos de victoria al ser derrotado.");
    }
}