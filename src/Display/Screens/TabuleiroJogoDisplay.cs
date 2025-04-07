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

            if (RegiaoTabuleiro.AreaDoInput.Equals(regiao.Regiao))
            {
                regiao.ExibirNoConsole();
            }
            else regiao.ExibirNoConsole();

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
        "╔═",
        $"║ Modelo: {carta.Atributos.Modelo}".PadRight(contentWidth),
        $"║ Velocidade: {carta.Atributos.VelocidadeMax} km/h".PadRight(contentWidth),
        $"║ Potência: {carta.Atributos.Potencia} HP".PadRight(contentWidth),
        $"║ Acelaração: {carta.Atributos.Aceleracao} seg - 100Km/h".PadRight(contentWidth),
        $"║ Consumo: {carta.Atributos.Consumo} Km/l".PadRight(contentWidth),
        $"║ Peso: {carta.Atributos.Peso} kg".PadRight(contentWidth),
        "╚═"
    };

        for (int i = 0; i < lines.Length; i++)
        {
            RenderizadorTabuleiro.WriteAt(2, 2 + i, lines[i]);
        }
    }


    public void ExibirCartarJogador(string cartaJogador, string carroJogador)
    {
        int y = cartaJogador.Split('\n').Length;

        RenderizadorTabuleiro.WriteAtV2InBlue(5, 4, cartaJogador);
        RenderizadorTabuleiro.WriteAtV2WithRandomColor(5, y + 3, carroJogador);
    }

    public void ExibirCartarCpu(string cartaCpu, string carroCpu)
    {
        int x = cartaCpu.Split('\n')[0].Length;
        int y = cartaCpu.Split('\n').Length;

        RenderizadorTabuleiro.WriteAtV2InRed(x + 100, 4, cartaCpu);
        RenderizadorTabuleiro.WriteAtV2WithRandomColor(x + 100, y + 3, carroCpu);
    }

}
