namespace Ucu.Poo.RoleplayGame;

public partial class Dwarf : Character
{
    public string HabPasiva { get; set; } //habilidad pasiva del enano
    public bool usandoPistola;

    public Dwarf(string nombre, List<Item> items, double vida) : base(nombre, items, vida)
    {
        HabPasiva = "Resistencia alta a la borrachera"; //agregar
    }
}