namespace Ucu.Poo.RoleplayGame;

public partial class Dwarf : Character
{
    public HachaEnana HachaEnana;
    public PistolaDePerno PistolaDePerno { get; set; }
    public string HabPasiva { get; set; } //habilidad pasiva del enano
    public bool usandoPistola;

    public Dwarf(string nombre, List<Item> items, double vida,HachaEnana HachaEnana,PistolaDePerno pistolaDePerno) : base(nombre, items, vida)
    {
        HachaEnana = HachaEnana;
        HabPasiva = "Resistencia alta a la borrachera"; //agregar
        usandoPistola = false;//comienza con el arma principal
        PistolaDePerno = PistolaDePerno;
    }
    public void AlternarArma()
    {
        usandoPistola = !usandoPistola; //cambia de arma
        string armaActual = usandoPistola ? "Pistola de Perno" : "Hacha doble pesada";
        Console.WriteLine($"{Nombre} ha cambiado su arma a {armaActual}");
    }
}