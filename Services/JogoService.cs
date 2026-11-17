using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using GestaojogosEFCore.Repositories;
using GestaoJogosEFCore.Models;

namespace GestaoJogosEFCore.Services
{
    public class JogoService
    {
        private readonly JogoRepository _repository;

        public JogoService(JogoRepository repository)
        {
            _repository = repository;
        }

        public List<Jogo> ListarTodosJogos() => _repository.Listar(); //* Criar um metodo desse jeito apenas simplifica ele, nao precisando passar um return
        public Jogo? BuscarPorId(int id) => _repository.BuscarPorId(id);
        
        public void CadastrarJogo(Jogo jogo) => _repository.Adicionar(jogo);
        public bool AtualizarJogo(Jogo JogoAtualizado) => _repository.Atualizar(JogoAtualizado);
        public bool ExcluirJogo(int id) => _repository.Excluir(id);

        public List<Desenvolvedora> ListarDesenvolvedoras() => _repository.ListarDesenvolvedoras();
        public void CadastrarDesenvolvedora(Desenvolvedora desenvolvedora) => _repository.AdicionarDesenvolvedora(desenvolvedora);
    }
}