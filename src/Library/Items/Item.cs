namespace Ucu.Poo.RoleplayGame;

//Clase que sera usada como base para los Items
//La letra del ejercicio pedia que cada personaje tuviera al menos 2 items
public abstract class Item
{
    public string Nombre { get; set; }
    public double Ataque { get; set; }
    public double Defensa { get; set; }
    public bool IsMagic { get; set; }

    public Item(string nombre, double ataque, double defensa, bool isMagic = false)
    {
        Nombre = nombre;
        Ataque = ataque;
        Defensa = defensa;
        IsMagic = isMagic;
    }
}

//Subclase para ítems de ataque
//Se creo para diferenciar los items de ataque y defensa
public class ItemDeAtaque : Item
{
    public ItemDeAtaque(string nombre, double ataque, bool isMagic = false) : base(nombre, ataque, 0)
    {
        if (ataque <= 0)
            throw new ArgumentException("Un ítem de ataque debe tener un valor de ataque mayor que 0.");
    }
}

//Subclase para ítems de defensa
//Se creo para diferenciar los items de ataque y defensa
public class ItemDeDefensa : Item
{
    public ItemDeDefensa(string nombre, double defensa, bool isMagic = false) : base(nombre, 0, defensa)
    {
        if (defensa <= 0)
            throw new ArgumentException("Un ítem de defensa debe tener un valor de defensa mayor que 0.");
    }
}

public class HachaEnana : ItemDeAtaque
{
    public HachaEnana(string nombre, double ataque, bool isMagic = false) : base(nombre, ataque, isMagic)
    {
        
    }
}

public class PistolaDePerno : ItemDeAtaque
{
    public int BalasIniciales { get; set; }
    public int BalasDisponibles {get; set; }

    public PistolaDePerno(string nombre, double ataque, int Balasiniciales, bool isMagic) : base(nombre, ataque)
    {
        BalasIniciales = Balasiniciales;
        BalasDisponibles = Balasiniciales;
    }

    public void DisminuirBalas()
    {
        if (BalasDisponibles > 0)
        {
            BalasDisponibles--;
        }
        else
        {
            Console.WriteLine("No queda municion.");
        }
    }
}
public class Baston : Item
{
    public Baston(string nombre, double Ataque, double Defensa, bool isMagic) : base(nombre, Ataque, Defensa)
    {
        
    }
}