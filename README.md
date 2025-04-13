# Super Trunfo UGB - Jogo de Cartas no Console

Este projeto é um jogo de Super Trunfo de carros, desenvolvido em C# puro, com execução no terminal. Ele foi desenvolvido como projeto acadêmico por alunos da faculdade UGB de Volta Redonda, com foco em arquitetura, separação de responsabilidades e exibição visual no console utilizando artes em ASCII.

## Índice

- [Funcionalidades](#funcionalidades)
- [Estrutura do Projeto](#estrutura-do-projeto)
- [Como Executar](#como-executar)
- [Jogabilidade](#jogabilidade)
- [Tecnologias Utilizadas](#tecnologias-utilizadas)
- [Autores](#autores)

---

## Funcionalidades

- Jogo completo de Super Trunfo entre jogador e CPU.
- Sistema de turnos com escolha de atributos.
- Exibição de cartas com desenhos ASCII.
- Renderização de molduras e telas no console.
- Pontuação e controle de rodadas.

## Estrutura do Projeto

O projeto está organizado em múltiplos subprojetos:

### `ConsoleApp`

- Ponto de entrada da aplicação (`Program.cs`).
- Gerencia o estado do jogo.
- Executa o loop principal e interage com os projetos `Core` e `Display`.

### `Core`

- Contém as entidades e a lógica principal do jogo.
- Principais classes:
  - `Carta`, `Atributos`, `Jogador`, `Baralho`
- Realiza o carregamento de dados a partir de um arquivo JSON.

### `Display`

- Responsável pela exibição visual no console.
- Utiliza artes ASCII para exibir cartas, molduras e mensagens.
- Classes como `TelaInicialDisplay` e `TabuleiroJogoDisplay` renderizam a interface.

## Como Executar

### Pré-requisitos

- [.NET SDK 8.0](https://dotnet.microsoft.com/en-us/download)

### Executar via terminal

```bash
# Clonar o repositório
git clone https://github.com/Goesg/ugb-super-trunfo-game

# Restaurar dependências
dotnet restore

# Compilar o projeto
dotnet build

# Executar o jogo
dotnet run --project src/ConsoleApp
```

### Executar via .exe (Windows)

- Acesse a pasta `publish/` gerada pelo build.
- Execute o arquivo `ConsoleApp.exe`.

## Jogabilidade

- O jogo inicia exibindo uma tela de boas-vindas.
- Pressione ENTER para iniciar.
- Em cada turno, você verá sua carta e escolherá um dos atributos:
  - Velocidade
  - Potência
  - Zero a cem
  - Consumo
  - Peso
 
- A CPU também joga sua carta.
- Quem tiver o maior valor no atributo escolhido vence o turno e recebe as cartas.
- O jogo segue até que um dos jogadores fique sem cartas ou selecione a opção de sair.

## Tecnologias Utilizadas

- C# 8.0
- .NET SDK 8.0
- Renderização ASCII no Console
- GitHub Actions para build automático

## Autores

- Diego 
- Sarah 
- Júlio 
- Gutemberg

---

**Este projeto foi desenvolvido com fins educacionais para a disciplina de programação em C-Sharp.**
