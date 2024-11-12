using NUnit.Framework;
using Ucu.Poo.RoleplayGame;

[TestFixture]
public class EncountersTests
{
    private Heroes hero;
    private Enemies enemy;
    private Encounters encounter;

    [SetUp]
    public void Setup()
    {
        // Inicializar héroe y enemigo con atributos básicos para las pruebas
        var arma1 = new ItemDeAtaque("Espada", 25);
        var armadura1 = new ItemDeDefensa("Armadura de placas", 15);

        hero = new Knight("Héroe", new List<Item>{arma1,armadura1}, 100,0);
        enemy = new Enemies("Enemigo", new List<Item>{arma1,armadura1}, 50, vp: 2); // Supongamos que el enemigo otorga 2 VP
        encounter = new Encounters(new List<Enemies> { enemy }, new List<Heroes> { hero });
    }

    [Test]
    public void Constructor_ThrowsException_WhenNoHeroesOrEnemies()
    {
        // Verificar que el constructor lanza una excepción si no hay héroes o enemigos en el encuentro
        Assert.Throws<ArgumentException>(() => new Encounters(new List<Enemies>(), new List<Heroes> { hero }));
        Assert.Throws<ArgumentException>(() => new Encounters(new List<Enemies> { enemy }, new List<Heroes>()));
    }

    [Test]
    public void DoEncounter_HeroesWin()
    {
        // Simular un encuentro donde el héroe vence al enemigo
        hero.Items.Add(new ItemDeAtaque("Espada", ataque: 200)); // Añadir un ítem que asegure la derrota del enemigo
        encounter.DoEncounter();
        
        // Verificar que al final del encuentro, los héroes han ganado y el enemigo ha sido derrotado
        Assert.AreEqual(0, encounter.EnemiesList.Count);
        Assert.AreEqual(1, encounter.HeroesList.Count); 
    }

    [Test]
    public void DoEncounter_EnemiesWin()
    {
        // Simular un encuentro donde el enemigo vence al héroe
        enemy.Items.Add(new ItemDeAtaque("Martillo", ataque: 200)); // Añadir un ítem que asegure la derrota del héroe
        encounter.DoEncounter();

        // Verificar que al final del encuentro, los enemigos han ganado y el héroe ha sido derrotado
        Assert.AreEqual(1, encounter.EnemiesList.Count);
        Assert.AreEqual(0, encounter.HeroesList.Count);
    }

    [Test]
    public void EnemiesAttackHeroes_ReducesHeroHealth()
    {
        // Ejecución de los ataques de los enemigos y verificación de la salud del héroe
        double initialHeroHealth = hero.VidaActual;
        encounter.TestEnemiesAttackHeroes();
        Assert.Less(hero.VidaActual, initialHeroHealth); // Verificar que la vida del héroe se ha reducido
    }

    [Test]
    public void HeroesAttackEnemies_ReducesEnemyHealth()
    {
        // Ejecución de los ataques de los héroes y verificación de la salud del enemigo
        double initialEnemyHealth = enemy.VidaActual;
        encounter.TestHeroesAttackEnemies();
        Assert.Less(enemy.VidaActual, initialEnemyHealth); // Verificar que la vida del enemigo se ha reducido
    }

    [Test]
    public void RemoveDeadCharactersWithNoHealth()
    {
        // Reducir la vida de héroes y enemigos a cero manualmente
        hero.VidaActual = 0;
        enemy.VidaActual = 0;

        // Ejecutar el método para eliminar personajes muertos
        encounter.TestRemoveDeadCharacters();

        // Verificar que ambos (héroes y enemigos) han sido removidos de sus listas
        Assert.AreEqual(0, encounter.HeroesList.Count);
        Assert.AreEqual(0, encounter.EnemiesList.Count);
    }
}
