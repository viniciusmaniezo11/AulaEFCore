
using System.Reflection;
using GestaoJogosEFCore.Data;
using GestaoJogosEFCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace GestaojogosEFCore.Repositories
{
    public class JogoRepository
    {
       private readonly DbContextOptions<GestaoJogosContext> _options;

       public JogoRepository (DbContextOptions<GestaoJogosContext> options)
        {
            _options =options;
        }

        public List<Jogo> Listar()
        {
            using var context = new GestaoJogosContext(_options);

            return context.Jogo //* Context representa o banco de dados, é a forma como C# reconhece o SQL.
                .Include(j => j.IdDesenvolvedoraNavigation) //* Carrega a navegação de desenvolvedora junto com os jogos, é como o JOIN.
                .OrderBy(j => j.IdJogo) //* Ordena por ID do jogo, igual o ORDER BY do SQL.
                .ToList(); //* Recebe tudo isso e lista os dados, sempre retornando um List<>.
        }

        public Jogo? BuscarPorId(int id) //* Retorna um objeto do tipo Jogo, caso não consiga achar retorna um null caso consiga retorna o objeto.
        {
            using var context = new GestaoJogosContext(_options);

            return context.Jogo
                .Include(j => j.IdDesenvolvedoraNavigation)
                .FirstOrDefault(j => j.IdJogo == id); //* Ele procura o jogo que possua o id atribui e retorna ele, caso não ache retorna o padrão null.
        }

        public void Adicionar(Jogo jogo)
        {
            using var context = new GestaoJogosContext(_options);

            context.Jogo.Add(jogo);
            context.SaveChanges(); //* Salva as alterações dentro do banco de dados, para não correr o risco de salvar apenas na maquina local.
        }

        public bool Atualizar(Jogo JogoAtualizado)
        {
            using var context = new GestaoJogosContext(_options);

            var JogoExistente = context.Jogo.Find(JogoAtualizado.IdJogo); //* Vê se existe o jogo dentro do banco

            if (JogoExistente is null)
            {
                return false;
            }

            JogoExistente.IdDesenvolvedora = JogoAtualizado.IdDesenvolvedora; //* Mapeia as informações do jogo existente e atribui os valores atualizados.
            JogoExistente.Nome = JogoAtualizado.Nome;
            JogoExistente.Genero = JogoAtualizado.Genero;
            JogoExistente.AnoLancamento = JogoAtualizado.AnoLancamento;
            JogoExistente.Preco = JogoAtualizado.Preco;

            context.SaveChanges();
            return true;
        }

        public bool Excluir(int id)
        {
            using var context = new GestaoJogosContext(_options);
            var JogoExistente = context.Jogo.Find(id); //* Identifica se o ID é valido.

            if (JogoExistente is null)
            {
                return false;
            }

            context.Jogo.Remove(JogoExistente);
            context.SaveChanges();
            return true;
        }

        public List<Desenvolvedora> ListarDesenvolvedoras()
        {
            using var context = new GestaoJogosContext(_options);

            return context.Desenvolvedora
                .OrderBy(d => d.Nome)
                .ToList();
        }

        public void AdicionarDesenvolvedora(Desenvolvedora desenvolvedora)
        {
            using var context = new GestaoJogosContext(_options);

            context.Desenvolvedora.Add(desenvolvedora);
            context.SaveChanges();
        }
    }
}