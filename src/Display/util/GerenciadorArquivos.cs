using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Display.util
{
    public class GerenciadorArquivos
    {
        public string ObterConteudoArquivoPorNome(string nomeArquivo)
        {
            var nomeCompletoRecurso = $"Display.ArquivosDisplay.{nomeArquivo}";
            using Stream? stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(nomeCompletoRecurso);

            if (stream == null)
                throw new Exception($"Erro ao exibir tela inicial do jogo. Msg: Recurso embutido '{nomeArquivo}' não encontrado no assembly.");

            using var reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }

    }
}
