using System;
using Core;
using Display.Enum;

namespace Display;

public class TabuleiroJogoDisplay : Display
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
            regiao.CoordenadasRegiao = regiao.Regiao.GerarCoordenadasEmTempoReal();
            regiao.ExibirNoConsole();
        }

        Console.CursorVisible = false;
    }

    public static void ExibirPlacar(Jogador? jogador, Jogador? cpu)
    {
        if (jogador == null || cpu == null)
        {
            throw new Exception("jogadores não informados");
        }

        string textoPlacar = $"Placar - {jogador.Nome}: {jogador.Cartas.Count} cartas  |  {cpu.Nome}: {cpu.Cartas.Count} cartas";
        var regiaoDoJogoConsole = _regioesTabuleiro.GetValueOrDefault(RegiaoTabuleiro.AreaDoJogo);


        TabuleiroRegiaoConsole.ExibirPlacar(textoPlacar);
    }

    public void ExibirOpcoesAtributos()
    {
        RenderizadorTabuleiro.ShowInputOptions();
    }

    public void ExibirCartaComCarroJogador(string cartaJogador, string carroJogador)
    {
        int y = cartaJogador.Split('\n').Length;

        RenderizadorTabuleiro.ImprimirNaTelaComCor(cartaJogador, new PosicaoCursor(5, 4), ConsoleColor.Blue);
        RenderizadorTabuleiro.ImprimirNaTelaComCorAleatoria(carroJogador, new PosicaoCursor(5, y + 3));
    }

    public void ExibirCartaComCarroCpu(string cartaCpu, string carroCpu)
    {
        int x = cartaCpu.Split('\n')[0].Length;
        int y = cartaCpu.Split('\n').Length;

        RenderizadorTabuleiro.ImprimirNaTelaComCor(cartaCpu, new PosicaoCursor(x + 100, 4), ConsoleColor.Red);
        RenderizadorTabuleiro.ImprimirNaTelaComCorAleatoria(carroCpu, new PosicaoCursor(x + 100, y + 3));
    }

}
