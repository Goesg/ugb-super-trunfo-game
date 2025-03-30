using System;

namespace Core;

public class Jogador
{
    public string Nome { get; }
    public LinkedList<Carta> Cartas { get; }

    public Jogador(string nome, LinkedList<Carta> cartas)
    {
        Nome = nome;
        Cartas = cartas;
    }

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
