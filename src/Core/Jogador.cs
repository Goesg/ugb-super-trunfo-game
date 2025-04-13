using System;

namespace Core;

public class Jogador(string nome, LinkedList<Carta> cartas)
{
    public string Nome { get; } = nome;
    public LinkedList<Carta> Cartas { get; } = cartas;

    public Carta JogarCartaDoTopo()
    {
        Carta carta = Cartas.First();
        Cartas.RemoveFirst();
        return carta;
    }

    public void ReceberCarta(Carta carta)
    {
        Cartas.AddLast(carta);
    }

    public bool PossuiCartas(){
        return Cartas.Count > 0;
    }

}
