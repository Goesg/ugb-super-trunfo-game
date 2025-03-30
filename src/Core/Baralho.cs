using System;
using System.Text.Json;

namespace Core;

public class Baralho
{
    private List<Carta> _cartas = [];
    private Random _random = new();
    private GerenciadorDeArquivos _gerenciadorDeArquivos = new();
    private readonly string _nomeArquivoJsonAtributosCartasSuperTrunfo = "cartas_super_trunfo_tema_carros_esportivos.json";

    public Baralho()
    {
        var _atributosCartasSuperTrunfoCarros = ObterAtributosCartas();
        _atributosCartasSuperTrunfoCarros.ForEach((atributo) => _cartas.Add(new Carta(atributo)));
    }

    private List<Atributos> ObterAtributosCartas()
    {
        var atributosCarroJson = _gerenciadorDeArquivos.ObterConteudoArquivoPorNome(_nomeArquivoJsonAtributosCartasSuperTrunfo);
        return JsonSerializer.Deserialize<List<Atributos>>(atributosCarroJson)!;
    }

    public void Embaralhar()
    {
        for (int i = 0; i < _cartas.Count; i++)
        {
            int j = _random.Next(i, _cartas.Count);
            (_cartas[i], _cartas[j]) = (_cartas[j], _cartas[i]);
        }
    }

    public (LinkedList<Carta> cartasJogador, LinkedList<Carta> cartasCpu) DistribuirEntreJogadores()
    {
        LinkedList<Carta> jogador = new();
        LinkedList<Carta> cpu = new();

        for (int i = 0; i < _cartas.Count; i++)
        {
            if (i % 2 == 0)
                jogador.AddLast(_cartas[i]);
            else
                cpu.AddLast(_cartas[i]);
        }

        return (jogador, cpu);
    }
}
