using System;

namespace Display;

public class PosicaoCursor(int espacosAEsquerda, int espacosDoTopo)
{
    public int EspacosAEsquerda { get; set; } = espacosAEsquerda;
    public int EspacosDoTopo { get; set; } = espacosDoTopo;

    public void IncrementarEspacosDoTopo(int quantidade)
    {
        EspacosDoTopo += quantidade;
    }
}

