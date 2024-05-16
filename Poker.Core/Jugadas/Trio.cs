namespace Poker.Core.Jugadas;

public class    Trio : IJugada
{
    public string Nombre => "Trio";
    public byte Prioridad => 7;
public Resultado Aplicar(List<Carta> cartas)
{
    if (cartas.Count == 0)
        throw new ArgumentException("No hay cartas");

    var valorCounts = cartas.GroupBy(carta => carta.Valor).ToDictionary(group => group.Key, group => group.Count());

    byte valor = 0;

    foreach (var pair in valorCounts)
    {
        if (pair.Value == 3)
        {
            valor = (byte)pair.Key;
            break;
        }
    }
        return new Resultado(Prioridad, 0);
}
}