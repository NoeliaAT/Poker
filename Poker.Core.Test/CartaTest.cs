namespace Poker.Core.Test;
public class CartaTest
{
    Carta _seisTrebol = new(EPalo.Trebol, EValor.Seis);

    [Fact]
    public void ToStringOK()
        => Assert.Equal("Carta { Palo = Trebol, Valor = Seis }", _seisTrebol.ToString());
}