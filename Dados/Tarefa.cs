using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace To_Do_List.Dados
{
    internal class Tarefa
    {
        public Tarefa(int id, string descricao)
        {
            Id = id;
            Descricao = descricao;
        }

        public int Id { get; set; }

        public string Descricao { get; set; }
    }
}
