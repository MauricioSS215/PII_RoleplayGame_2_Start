using System.Xml.Serialization;
using Ucu.Poo.RoleplayGame;
namespace Program;
public class Program
{
    static void Main(string[] args)
    {
        //Primero creamos UNICAMENTE ítems de ataque y defensa, algunos seran magicos.
        var baston = new Baston("Bastón Mágico", 10, 10, true);
        Spell Rayo = new Spell("Rayo", 100, 0);
        var librohechizo = new SpellsBook();
        librohechizo.AddSpell(Rayo);
        var hachaEnano = new HachaEnana("Hacha doble pesada",40,false);
        var pistolaDePerno = new PistolaDePerno("Pistola de perno de 3 tiros", 5, Balasiniciales: 60,false);
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
        var caballero = new Knight("Artoria", itemsKnight, 100, 0);
        var elfo = new Elfo("Legolas", itemsElfo, 120, arco1, 0);
        var enano = new Dwarf(nombre: "Karaz Ankor", itemsDwarf, vida: 250,hachaEnano,pistolaDePerno, 0);
        var mago = new Sorcerer(nombre: "ShangTsung", itemsSorcerer, 140, librohechizo, 0);
        mago.AddBaston(baston);
        
        
        //Mostramos las estadisticas de nuestros personajes
        caballero.GetStats();
        elfo.GetStats();
        enano.GetStats();
        mago.GetStats();
        
        //Aplicamos metodos para mostrar su funcionamiento, en este caso atacamos al caballero
        elfo.DealDamage(caballero);
        enano.DealDamage(caballero);
        enano.AlternarArma();
        enano.DealDamage(caballero);
        Console.WriteLine("");
        mago.DealDamage(caballero);
        
        //Mostramos nuevamente el status actual del caballero, deberia tener menos vida
        caballero.GetStats();
        
        //Por ultimo llamamos al metodo HealDamage y luego mostramos sus stats para ver que realmente se curo
        caballero.HealDamage();
        caballero.GetStats();

        Giant gigante1 = new Giant("Gigante1", new List<Item> { arma1, armadura1 }, 40, 2);
        Giant gigante2 = new Giant("Gigante2", new List<Item> { arma1, armadura1 }, 40, 2);
        Giant gigante3 = new Giant("Gigante3", new List<Item> { arma1, armadura1 }, 40, 1);
        Giant gigante4 = new Giant("Gigante4", new List<Item> { arma1, armadura1 }, 40, 2);
        Giant gigante5 = new Giant("Gigante5", new List<Item> { arma1, armadura1 }, 40, 2);
        Giant gigante6 = new Giant("Gigante6", new List<Item> { arma1, armadura1 }, 40, 1);
        Giant gigante7= new Giant("Gigante7", new List<Item> { arma1, armadura1 }, 40, 2); 
        Necromancer QuanChi = new Necromancer();
        Plumber Ricardo = new Plumber();
        WildWarrior Alcoth = new WildWarrior();
        Knight caballero1 = new Knight("Caballero1", new List<Item> { arma1, armadura1 }, 60, 0);
        Knight caballero2 = new Knight("Caballero2", new List<Item> { arma1, armadura1 }, 60, 0);
        Knight caballero3 = new Knight("Caballero3", new List<Item> { arma1, armadura1 }, 60, 0);
        Elfo arquero1 = new Elfo("Arquero1", new List<Item> { arma1, armadura1 }, 40, arco1, 0);
        Dwarf enano1 = new Dwarf("Enano1", new List<Item> { arma1, armadura1 }, 60, hachaEnano,pistolaDePerno,0);
        
        List<Enemies> ListaEnemies = new List<Enemies> { gigante1, gigante2, gigante3, gigante4, gigante5, gigante6, gigante7, QuanChi, Ricardo, Alcoth };
        List<Heroes> ListaHeroes = new List<Heroes> { caballero1, caballero2, caballero3, arquero1, enano1 };
        Encounters Encuentro = new Encounters(ListaEnemies, ListaHeroes);
        Encuentro.DoEncounter();
    }
}