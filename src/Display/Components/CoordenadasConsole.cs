using System;

namespace Display;

public class CoordenadasConsole
{

    public required PosicaoCursor PosicaoInicialCursor { get; init; }

    public required PosicaoCursor PosicaoCursor { get; init; }

    public required AreaConsole AreaOcupadaConsole { get; init; }

    public static CoordenadasConsoleBuilder Builder() => new();

    public class CoordenadasConsoleBuilder
    {
        private int _cursorEspacosAEsquerda;
        private int _cursorEspacosDoTopo;
        private int _largura;
        private int _altura;

        public CoordenadasConsoleBuilder ComEspacosAEsqueda(int cursorEspacosAEsquerda)
        {
            _cursorEspacosAEsquerda = cursorEspacosAEsquerda;
            return this;
        }

        public CoordenadasConsoleBuilder ComEspacosDoTopo(int cursorEspacosDoTopo)
        {
            _cursorEspacosDoTopo = cursorEspacosDoTopo;
            return this;
        }

        public CoordenadasConsoleBuilder ComLargura(int largura)
        {
            _largura = largura;
            return this;
        }

        public CoordenadasConsoleBuilder ComAltura(int altura)
        {
            _altura = altura;
            return this;
        }

        public CoordenadasConsole Build()
        {
            return new CoordenadasConsole
            {
                PosicaoInicialCursor = new(_cursorEspacosAEsquerda, _cursorEspacosDoTopo),
                PosicaoCursor = new(_cursorEspacosAEsquerda, _cursorEspacosDoTopo),
                AreaOcupadaConsole = new(_largura, _altura)
            };
        }
    }

    public int ObterLargura()
    {
        return AreaOcupadaConsole.Largura;
    }

    public int ObterAltura()
    {
        return AreaOcupadaConsole.Altura;
    }

    public void IncrementarEspacosDoTopo(int quantidade)
    {
        PosicaoCursor.IncrementarEspacosDoTopo(quantidade);
    }

    public void IncrementarEspacosDoTopoTemporariamente(int quantidade)
    {
        PosicaoCursor.EspacosDoTopo = (PosicaoInicialCursor.EspacosDoTopo + quantidade);
    }

}
