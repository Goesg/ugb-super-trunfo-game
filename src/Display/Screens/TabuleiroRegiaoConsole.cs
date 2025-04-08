using System;
using Display.Enum;

namespace Display;

public class TabuleiroRegiaoConsole(RegiaoTabuleiro regiaoTabuleiro, CoordenadasConsole coordenadasRegiaoConsole)
{
    public RegiaoTabuleiro Regiao { get; } = regiaoTabuleiro;

    public CoordenadasConsole CoordenadasRegiao { get; set; } = coordenadasRegiaoConsole;

    public void ExibirNoConsole()
    {
        RenderizadorTabuleiro.DesenharMoldura(CoordenadasRegiao);
    }

    public static void ExibirPlacar(string textoPlacar)
    {
        RenderizadorTabuleiro.ImprimirNaTela(textoPlacar, new PosicaoCursor(4, 2));
    }


}
