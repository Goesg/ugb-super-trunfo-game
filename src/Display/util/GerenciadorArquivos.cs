using System;

namespace Display.util
{

    public class GerenciadorArquivos
    {

        private readonly string caminhoPastaDeArquivos = AppDomain.CurrentDomain.BaseDirectory;
        private readonly string nomeDaPastaDeArquivos = "ArquivosDisplay";

        public string ObterConteudoArquivoPorNome(string nomeArquivo)
        {
            string caminhoDoArquivo = MontarCaminhoCompletoDoArquivo(caminhoPastaDeArquivos, nomeDaPastaDeArquivos, nomeArquivo);

            if (!File.Exists(caminhoDoArquivo))
            {
                throw new Exception("Arquivo nao encontrado: " + nomeArquivo);
            }

            return ObterConteudoDoArquivo(caminhoDoArquivo);
        }

        internal string MontarCaminhoCompletoDoArquivo(string caminhoPastaDeArquivos, string nomeDaPastaDeArquivos, string nomeArquivo)
        {
            return Path.Combine(caminhoPastaDeArquivos, nomeDaPastaDeArquivos, nomeArquivo);
        }

        internal string ObterConteudoDoArquivo(string caminhoDoArquivo)
        {
            return File.ReadAllText(caminhoDoArquivo);
        }
    }
}