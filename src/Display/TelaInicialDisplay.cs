using System;
using Display.util;

namespace Display;

public class TelaInicialDisplay
{

    private readonly string nomeArquivoTxtDoNomeDoJogoEmAscii = "logo-nome-jogo-ascii.txt";
    private readonly GerenciadorArquivos gerenciadorArquivos = new GerenciadorArquivos();

    private readonly string fraseTelaInicial = "\n\n\n Pressione Enter para inicar...";

    public void ExibirNoConsole()
    {
        try
        {
            string nomeDoJogoEmAscii = gerenciadorArquivos.ObterConteudoArquivoPorNome(nomeArquivoTxtDoNomeDoJogoEmAscii);
            Console.Clear();
            Console.WriteLine(nomeDoJogoEmAscii);
            Console.WriteLine(fraseTelaInicial);
        }
        catch (Exception e)
        {
            throw new Exception($"Erro ao exibir tela inicial do jogo. Msg: {e.Message}");
        }
    }
}
