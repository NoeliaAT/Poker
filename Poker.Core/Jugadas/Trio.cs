namespace Poker.Core.Jugadas;
public class Trio : IJugada
{
    public string Nombre => "Trio";
    public byte Prioridad => 7;
    public Resultado Aplicar(List<Carta> cartas)
    {
        if (cartas.Count == 0)
            throw new ArgumentException("No hay cartas");

        var ordenadasPorValor = cartas.OrderBy(c => c.Valor);

        var valor = ordenadasPorValor.First().Valor == EValor.As ?
                        (byte)14 : // Aca use el valor 'Alto' del As
                        (byte)ordenadasPorValor.Last().Valor; // Como estan ordenadas, la ultima es la mayor 

        return new Resultado(Prioridad, valor);
    }
}



namespace Poker12.Core.Jugadas;

public class FullHouse : IJugada
{
    public string Nombre => "FullHouse";
    public byte Prioridad => 4;
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

    if (valor != 0 && valorCounts.Count == 2 && valorCounts.ContainsValue(2))
        return new Resultado(Prioridad, valor);
    else
        return new Resultado(Prioridad, 0);
}
}