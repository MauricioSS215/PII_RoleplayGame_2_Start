namespace Ucu.Poo.RoleplayGame;

public class Elfo : Heroes
{
    public Arco ArcoElfo { get; set; }
    public Elfo(string nombre, List<Item> items, double vida, Arco arcoElfo, int vp)
        : base(nombre, items, vida, vp)
    {
        ArcoElfo = arcoElfo;
    }

    // Sobrescribe el método DealDamage para manejar el caso del arco
    public override double DealDamage(Character enemigo)
    {
        if (ArcoElfo != null && ArcoElfo.FlechasDisponibles > 0)
        {
            ArcoElfo.DisminuirFlechas();  // Disminuir el número de flechas
            double damage = GetAttackValue();  // Obtener el valor de ataque del elfo
            double realDamage = damage * (1 - (enemigo.GetDefValue() / 100));  // Calcular el daño real, teniendo en cuenta la defensa del enemigo
            enemigo.VidaActual = enemigo.VidaActual - realDamage;  // Aplicar el daño al enemigo

            // Mensajes en consola sobre el ataque y el estado actual
            Console.WriteLine($"{Nombre} ha disparado una flecha a {enemigo.Nombre} y le ha hecho {realDamage} de daño.");
            Console.WriteLine($"La vida restante de {enemigo.Nombre} es {enemigo.VidaActual}.");
            Console.WriteLine($"Flechas restantes: {ArcoElfo.FlechasDisponibles}");
        }
        else
        {
            Console.WriteLine("No hay flechas disponibles para atacar.");
        }
        Console.WriteLine("");
        return enemigo.VidaActual;  // Retornar la vida actual del enemigo después del ataque
    }

    public override void GetStats()
    {
        Console.WriteLine($"{Nombre} tiene los siguientes stats:\n \nNivel de vida: {VidaActual}");
        foreach (var item in Items)
        {
            Console.WriteLine($"{item.Nombre} - Ataque: {item.Ataque}, Defensa: {item.Defensa}");
        }
        Console.WriteLine($"Le quedan {ArcoElfo.FlechasDisponibles} flechas disponibles");
        Console.WriteLine("");
    }
}
