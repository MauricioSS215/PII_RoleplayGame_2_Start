namespace Ucu.Poo.RoleplayGame;

public class Encounters
{
    public List<Enemies> EnemiesList;
    public List<Heroes> HeroesList;

    public Encounters(List<Enemies> enemiesList, List<Heroes> heroesList)
    {
        this.EnemiesList = enemiesList;
        this.HeroesList = heroesList;
    }

    public void DoEncounter()
    {
       
    }

    public bool AllEnemiesDead()
    {
        foreach (var enemy in EnemiesList)
        {
            if (!enemy.IsDead())
            {
                return false;
            }
        }

        Console.WriteLine("Todos los enemigos han sido derrotados");
        return true;
    }
    public bool AllHeroesDead()
    {
        foreach (var hero in HeroesList)
        {
            if (!hero.IsDead())
            {
                return false;
            }
        }

        Console.WriteLine("Todos los héroes han sido derrotados");
        return true;
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