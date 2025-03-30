using System;
using Display.Enum;

namespace Display;

public class TabuleiroRegiaoConsole
{
    public RegiaoTabuleiro Regiao { get; }

    public CoordenadasConsole Coordenadas { get; set; }

    public TabuleiroRegiaoConsole(RegiaoTabuleiro regiaoTabuleiro, CoordenadasConsole coordenadasConsole)
    {
        Regiao = regiaoTabuleiro;
        Coordenadas = coordenadasConsole;
    }


    public void ExibirNoConsole()
    {
        RenderizadorTabuleiro.DrawBox(
            Coordenadas.PosicaoCursor.EspacosAEsquerda,
            Coordenadas.PosicaoCursor.EspacosDoTopo,
            Coordenadas.AreaConsole.Largura,
            Coordenadas.AreaConsole.Altura
        );
    }


    public void ExibirPlacar(string textoPlacar)
    {
        RenderizadorTabuleiro.WriteAt
        (
            4, 1, textoPlacar
        );
    }

    public void ExibirOpcoesAtributos()
    {
        RenderizadorTabuleiro.ShowInputOptions();
    }
    

}
