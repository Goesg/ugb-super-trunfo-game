using System;
using Display.Enum;

namespace Display;

public class ConstrutorDisplay
{

    public static TelaInicialDisplay ConstrutirDisplayTelaInicial()
    {
        return new TelaInicialDisplay();
    }

    public static TabuleiroJogoDisplay ConstrutirDisplayTabuleiro()
    {
        var tabuleiroJogoDisplay = new TabuleiroJogoDisplay();
        tabuleiroJogoDisplay.AdicionarRegiao(new TabuleiroRegiaoConsole(RegiaoTabuleiro.AreaDoJogo, RegiaoTabuleiro.AreaDoJogo.GerarCoordenadasEmTempoReal()));
        tabuleiroJogoDisplay.AdicionarRegiao(new TabuleiroRegiaoConsole(RegiaoTabuleiro.AreaDoInput, RegiaoTabuleiro.AreaDoInput.GerarCoordenadasEmTempoReal()));

        return tabuleiroJogoDisplay;
    }
}
