using Ucu.Poo.RoleplayGame;
namespace Program;
public class Program
{
    static void Main(string[] args)
    {
        // Primero creamos UNICAMENTE ítems de ataque y defensa, algunos seran magicos.
        var baston = new Baston("Bastón Mágico", 10, 10, true);
        Spell Rayo = new Spell("Rayo", 100, 0);
        var librohechizo = new SpellsBook();
        librohechizo.AddSpell(Rayo);
        var pistolaDePerno = new PistolaDePerno("Pistola de perno de 3 tiros", 5, balasIniciales: 60,false);
        var hachaEnano = new HachaEnana("Hacha doble pesada",40,false);
        var armaduraEnano = new ItemDeDefensa("Armadura de Acero Enana", 40, false);
        var arma1 = new ItemDeAtaque("Espada", 25);
        var arma2 = new ItemDeAtaque("Daga Oscura", 15);
        var armaMagica1 = new ItemDeAtaque("MagicSword", 80, true);
        var armaMagica2 = new ItemDeAtaque("Holy Whip", 75, true);
        var escudo1 = new ItemDeDefensa("Escudo de hierro", 20);
        var escudo2 = new ItemDeDefensa("Escudo encantado", 15);
        var armadura1 = new ItemDeDefensa("Armadura de placas", 15);
        var armadura2 = new ItemDeDefensa("Armadura del Norte", 30);
        var arco1 = new Arco("Flechas de hielo", 10, 15);
        
        //Ahora crearemos las listas de items que seran usadas por los personajes
        var itemsKnight = new List<Item> { arma1, escudo1, armadura1 };
        var itemsDwarf = new List<Item>{hachaEnano,armaduraEnano};
        var itemsElfo = new List<Item> { arco1, escudo2, armadura2};
        var itemsSorcerer = new List<Item> { armaMagica1, escudo1, armadura1 };
        
        //En este momento creamos a nuestros personajes
        var caballero = new Knight("Artoria", itemsKnight, 100);
        var elfo = new Elfo("Legolas", itemsElfo, 120, arco1);
        var enano = new Dwarf(nombre: "Karaz Ankor", itemsDwarf, vida: 250,hachaEnano,pistolaDePerno);
        var mago = new Sorcerer(nombre: "ShangTsung", itemsSorcerer, 140, librohechizo);
        mago.AddBaston(baston);


        //Mostramos las estadisticas de nuestros personajes
        caballero.GetStats();
        elfo.GetStats();
        //enano.GetStats();
        mago.GetStats();

        //Aplicamos metodos para mostrar su funcionamiento, en este caso atacamos al caballero
        elfo.DealDamage(caballero);
        enano.DealDamage(caballero);
        mago.DealDamage(caballero);

        //Mostramos nuevamente el status actual del caballero, deberia tener menos vida
        caballero.GetStats();

        //Por ultimo llamamos al metodo HealDamage y luego mostramos sus stats para ver que realmente se curo
        caballero.HealDamage();
        caballero.GetStats();

    }
}