using System;
using System.Collections.Generic;

namespace GestaoJogosEFCore.Models;

public partial class Jogo //* Representa a tabela e suas colunas
{
    public int IdJogo { get; set; }

    public int IdDesenvolvedora { get; set; }

    public string Nome { get; set; } = null!;

    public string Genero { get; set; } = null!;

    public int AnoLancamento { get; set; }

    public decimal Preco { get; set; }

    public virtual Desenvolvedora IdDesenvolvedoraNavigation { get; set; } = null!; //* Navigation -> Tras as informações das tabelas que se relacionam

    public virtual ICollection<JogadorJogo> JogadorJogo { get; set; } = new List<JogadorJogo>();
}
