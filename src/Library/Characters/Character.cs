namespace Ucu.Poo.RoleplayGame;

public abstract class Character
{
    public string Nombre { get; set; }
    public double VidaMax { get; set; }
    public double VidaActual { get; set; }
    public List<Item> Items { get; set; }  // Lista de ítems

    public Character(string nombre, List<Item> items, double vida)
    {
        Nombre = nombre;
        Items = items;
        VidaMax = vida;
        VidaActual = vida; //Al comenzar, la vidaActual y la maxima seran iguales
    }
    
    public double GetAttackValue()
    {
        double totalAtaque = 0;
        foreach (var item in Items)
        {
            if (item is ItemDeAtaque)
            {
                totalAtaque += item.Ataque;
            }
        }
        return totalAtaque;
    }
    
    public double GetDefValue()
    {
       double totalDefensa = 0;
       foreach (var item in Items)
       {
            if (item is ItemDeDefensa)
            {
                totalDefensa += item.Defensa;
                if (item is CapaElfo capaElfo)
                {
                    totalDefensa += capaElfo.BonusDefensa;
                }
            }
       }
       return totalDefensa;
    }
    public virtual double DealDamage(Character enemigo)//Sirve para atacar otro Personaje
    {
        double damage = GetAttackValue();
        double realDamage = damage*(1-( enemigo.GetDefValue() /100));//Se inmplemento que la defensa disminuye el valor del ataque en un porcentaje
        //Por ejemplo:Si la defensa es 20, el valor del ataque se vera disminuido en %20.
        enemigo.VidaActual = enemigo.VidaActual - realDamage;
        Console.WriteLine($"{Nombre} ha atacado a {enemigo.Nombre} y le ha hecho {realDamage} de daño.");
        Console.WriteLine($"La vida restante de {enemigo.Nombre} es {enemigo.VidaActual}.");
        Console.WriteLine("");
        return enemigo.VidaActual;
    }

    public void HealDamage()
    {
        if (this.VidaActual < VidaMax)
        {
            this.VidaActual = VidaMax;
        }
        Console.WriteLine($"El caballero {Nombre} ha sido curado, su vida actual es {VidaActual}");
    }
    public virtual void GetStats()
    {
        Console.WriteLine($"{Nombre} tiene los siguientes stats:\n \nNivel de vida: {VidaActual}");
        foreach (var item in Items)
        {
            Console.WriteLine($"{item.Nombre} - Ataque: {item.Ataque}, Defensa: {item.Defensa}");
        }
        Console.WriteLine("");
    }
}