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

                    // Si el héroe mata al enemigo, gana los VP
                    if (enemy.VidaActual <= 0)
                    {
                        hero.VP += enemy.VP;
                        Console.WriteLine($"{hero.Nombre} ha ganado {enemy.VP} puntos de victoria.");
                        
                        // Si el héroe alcanza 5+ VP, se cura
                        if (hero.VP >= 5)
                        {
                            hero.HealDamage();
                            Console.WriteLine($"{hero.Nombre} se ha curado por tener 5 o más puntos de victoria.");
                        }
                    }
                }
            }
        }
        
    }
    private void RemoveDeadCharacters()
    {
        HeroesList.RemoveAll(h => h.VidaActual <= 0);
        EnemiesList.RemoveAll(e => e.VidaActual <= 0);
    }
    

    public void AttackEnemies()
    {
        for (int i = 0; i < EnemiesList.Count; i++)
        {
            if(i < HeroesList.Count)
            {
                EnemiesList[i].DealDamage(HeroesList[i]);
                Console.WriteLine($"Se ha atacado {i}");
            }
            else
            {
                EnemiesList[i].DealDamage(HeroesList[i - HeroesList.Count]);
                Console.WriteLine($"Se ha atacado {i}");
            }

            
        }
    }
}