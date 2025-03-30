using System;
using Display.Enum;

namespace Display;

public class TabuleiroJogoDisplay: Display
{

    private static readonly Dictionary<RegiaoTabuleiro, TabuleiroRegiaoConsole> _regioesTabuleiro = [];

    public void AdicionarRegiao(TabuleiroRegiaoConsole tabuleiroRegiaoConsole)
    {
        _regioesTabuleiro[tabuleiroRegiaoConsole.Regiao] = tabuleiroRegiaoConsole;
    }

    public override void ExibirNoConsole()
    {
        LimparTerminal();
       
        foreach (var regiao in _regioesTabuleiro.Values)
        {
            regiao.Coordenadas = regiao.Regiao.GerarCoordenadasEmTempoReal();
            regiao.ExibirNoConsole();
        }

        Console.SetCursorPosition(9, Console.WindowHeight -2);
    }
}
