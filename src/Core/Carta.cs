using System;
using Core.ArquivosCore;

namespace Core;

public class Carta(Atributos atributos)
{
    public Atributos Atributos = atributos;

    public double ObterValorAtributoPorInput(AtributoInput input)
    {
        return input switch
        {
            AtributoInput.Velocidade => Atributos.VelocidadeMax,
            AtributoInput.ZeroACem => (double)Atributos.Aceleracao,
            AtributoInput.Potencia => Atributos.Potencia,
            AtributoInput.Consumo => Atributos.Consumo,
            AtributoInput.Peso => Atributos.Peso,
            _ => throw new Exception($"Input inválido - {input.ToString()}")
        };
    }
}
