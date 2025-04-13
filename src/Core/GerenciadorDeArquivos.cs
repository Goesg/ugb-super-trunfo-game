using System;

namespace Core
{

    public class GerenciadorDeArquivos
    {
        private readonly string caminhoPastaDeArquivos = AppContext.BaseDirectory;

        private readonly string nomeDaPastaDeArquivos = "ArquivosCore";

        public string ObterConteudoArquivoPorNome(string nomeArquivo)
        {
            string caminhoDoArquivo = MontarCaminhoCompletoDoArquivo(caminhoPastaDeArquivos, nomeDaPastaDeArquivos, nomeArquivo);

            if (!File.Exists(caminhoDoArquivo))
            {
                throw new Exception("Arquivo nao encontrado");
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