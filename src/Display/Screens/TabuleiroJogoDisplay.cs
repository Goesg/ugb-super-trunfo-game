using System;
using Core;
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

        Console.CursorVisible = false;
    }

    public void ExibirPlacar(Jogador ?jogador, Jogador ?cpu)
    {
        if(jogador == null || cpu == null)
        {
            throw new Exception("jogadores não informados");
        }

        string textoPlacar = $"Placar - {jogador.Nome}: {jogador.Cartas.Count} cartas  |  {cpu.Nome}: {cpu.Cartas.Count} cartas";
        _regioesTabuleiro.GetValueOrDefault(RegiaoTabuleiro.AreaDoJogo).ExibirPlacar(textoPlacar);
    }
    
    public void ExibirOpcoesAtributos()
    {
        RenderizadorTabuleiro.ShowInputOptions();
    }
    
}
