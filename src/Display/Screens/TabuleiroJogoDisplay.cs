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
            regiao.Coordenadas = regiao.Regiao.GerarCoordenadasEmTempoReal();
            regiao.ExibirNoConsole();
        }

        Console.CursorVisible = false;
    }

    public void ExibirPlacar(Jogador? jogador, Jogador? cpu)
    {
        if (jogador == null || cpu == null)
        {
            throw new Exception("jogadores não informados");
        }

        string textoPlacar = $"Placar - {jogador.Nome}: {jogador.Cartas.Count} cartas  |  {cpu.Nome}: {cpu.Cartas.Count} cartas";
        var regiaoDoJogoConsole = _regioesTabuleiro.GetValueOrDefault(RegiaoTabuleiro.AreaDoJogo);

        regiaoDoJogoConsole?.ExibirPlacar(textoPlacar);
    }

    public void ExibirOpcoesAtributos()
    {
        RenderizadorTabuleiro.ShowInputOptions();
    }

    public void ExibirCarta(Carta carta)
    {
        int contentWidth = 24;
        string[] lines =
        {
        "╔" + new string('═', contentWidth) + "╗",
        $"║ Modelo: {Trunc(carta.Atributos.Modelo, contentWidth - 7)}".PadRight(contentWidth) + "║",
        $"║ Velocidade: {carta.Atributos.VelocidadeMax} km/h".PadRight(contentWidth) + "║",
        $"║ Potência: {carta.Atributos.Potencia} HP".PadRight(contentWidth) + "║",
        $"║ Acelaração: {carta.Atributos.Aceleracao} seg - 100Km/h".PadRight(contentWidth) + "║",
        $"║ Peso: {carta.Atributos.Peso} kg".PadRight(contentWidth) + "║",
        "╚" + new string('═', contentWidth) + "╝"
    };

        for (int i = 0; i < lines.Length; i++)
        {
            RenderizadorTabuleiro.WriteAt(2, 2 + i, lines[i]);
        }
    }

            private static string Trunc(string text, int maxLength)
        {
            return text.Length <= maxLength ? text : text.Substring(0, maxLength - 1) + "…";
        }
}
