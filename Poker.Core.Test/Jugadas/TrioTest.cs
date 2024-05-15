using Poker12.Core.Jugadas;

namespace Poker12.Core.Test.Jugadas;
public class CartaAltaTest
{
    private IJugada _cartaAlta;
    public CartaAltaTest() => _cartaAlta = new CartaAlta();

    [Fact]
    public void FallaPorJugadaSinCartas()
    {
        var jugada = new List<Carta>();

        Assert.Throws<ArgumentException>(() => _cartaAlta.Aplicar(jugada));
    }

    [Fact]
    public void PruebaConAS()
    {
        var jugada = new List<Carta>()
        {
            new(EPalo.Corazon, EValor.Diez),
            new(EPalo.Picas, EValor.As),
            new(EPalo.Corazon, EValor.Tres)
        };

        var resultado = _cartaAlta.Aplicar(jugada);

        Assert.Equal(14, resultado.Valor);
    }

    [Theory]
    [InlineData(EValor.Dos)]
    [InlineData(EValor.Cinco)]
    [InlineData(EValor.J)]
    public void CasoTrivialUnaCarta(EValor valor)
    {
        var jugada = new List<Carta>()
        {
            new(EPalo.Corazon, valor)
        };

        var resultado = _cartaAlta.Aplicar(jugada);

        Assert.Equal((byte)valor, resultado.Valor);
    }
}