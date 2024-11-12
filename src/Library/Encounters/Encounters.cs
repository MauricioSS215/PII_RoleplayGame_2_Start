namespace Ucu.Poo.RoleplayGame;

public class Encounters
{
    public List<Enemies> EnemiesList;
    public List<Heroes> HeroesList;

    public Encounters(List<Enemies> enemiesList, List<Heroes> heroesList)
    {
        if (heroesList.Count == 0 || enemiesList.Count == 0)
        {
            throw new ArgumentException("Debe haber al menos un héroe y un enemigo en el encuentro.");

        }
        this.EnemiesList = enemiesList;
        this.HeroesList = heroesList;
    }
    //Se usaron metodos publicos que llaman a los metodos privados para poder hacer las pruebas
    public void TestEnemiesAttackHeroes()  // Método de prueba pública
    {
        EnemiesAttackHeroes();
    }

    public void TestHeroesAttackEnemies()  // Método de prueba pública
    {
        HeroesAttackEnemies();
    }

    public void TestRemoveDeadCharacters()  // Método de prueba pública
    {
        RemoveDeadCharacters();
    }

    public void DoEncounter()
    {
        while (HeroesList.Count > 0 && EnemiesList.Count > 0)
        {
            //Los enemigos atacan a los héroes
            EnemiesAttackHeroes();

            //Los héroes sobrevivientes atacan a cada enemigo
            HeroesAttackEnemies();

            // Eliminar héroes y enemigos muertos
            RemoveDeadCharacters();
        }
        // Resultado del encuentro
        if (HeroesList.Count > 0)
        {
            Console.WriteLine("¡Los héroes han ganado el encuentro!");
        }
        else
        {
            Console.WriteLine("Los enemigos.. han ganado el encuentro.");
        }
    }

    private void EnemiesAttackHeroes()
    {
        Console.WriteLine("Turno de los enemigos:");
        for (int i = 0; i < EnemiesList.Count; i++)
        {
            Enemies enemy = EnemiesList[i];
            Heroes targetHero = HeroesList[i % HeroesList.Count];
            enemy.DealDamage(targetHero);
        }
    }
    private void HeroesAttackEnemies()
    {
        Console.WriteLine("Turno de los héroes:");
        foreach (Heroes hero in HeroesList)
        {
            foreach (Enemies enemy in EnemiesList)
            {
                if (enemy.VidaActual > 0)
                {
                    hero.DealDamage(enemy);
                }
            }
        }
        
    }
    private void RemoveDeadCharacters()
    {
        HeroesList.RemoveAll(h => h.VidaActual <= 0);
        EnemiesList.RemoveAll(e => e.VidaActual <= 0);
    }
}