#pragma warning disable
using To_Do_List.Dados;

namespace To_Do_List
{
    internal class ControllerLista
    {
        static int idAtual = 1;
        static void Main(string[] args)
        {
            Opcao opcao;
            var listaDeTarefas = new List<Tarefa>();

            do
            {
                do
                {
                    Console.WriteLine("O que você gostaria de fazer hoje?");
                    Console.WriteLine("1. Nova tarefa, 2. Exibir todas tarefas, 3. Excluir tarefa, 4. Editar tarefa, 5. Sair da lista de tarefas");
                    opcao = (Opcao)Convert.ToInt32(Console.ReadLine());

                    if (opcao != Opcao.IncluirTarefa && opcao != Opcao.ExibirTarefa && opcao != Opcao.ExcluirTarefa && opcao != Opcao.EditarTarefa && opcao != Opcao.SairDaLista)
                    {
                        Console.WriteLine("Opção inválida");
                    }

                } while (opcao != Opcao.IncluirTarefa && opcao != Opcao.ExibirTarefa && opcao != Opcao.ExcluirTarefa && opcao != Opcao.EditarTarefa && opcao != Opcao.SairDaLista);

                if (opcao == Opcao.SairDaLista)
                {
                    Console.WriteLine("Você saiu!");
                    break;
                }

                switch (opcao)
                {
                    case Opcao.IncluirTarefa:
                        listaDeTarefas = IncluirTarefa(listaDeTarefas);
                        break;
                    case Opcao.ExibirTarefa:
                        ExibirTarefas(listaDeTarefas);
                        break;
                    case Opcao.ExcluirTarefa:
                        listaDeTarefas = ExcluirTarefa(listaDeTarefas);
                        break;
                    case Opcao.EditarTarefa:
                        listaDeTarefas = EditarTarefa(listaDeTarefas);
                        break;
                }
            } while (opcao != Opcao.SairDaLista);
        }

        static List<Tarefa> IncluirTarefa(List<Tarefa> listaDeTarefas)
        {
            Console.WriteLine("Qual tarefa você gostaria de adcionar?");
            var descricao = Console.ReadLine();

            var tarefa = new Tarefa(idAtual, descricao);

            listaDeTarefas.Add(tarefa);

            idAtual++;

            return listaDeTarefas;
        }

        static void ExibirTarefas(List<Tarefa> listaDeTarefas)
        {
            foreach (var tarefa in listaDeTarefas)
            {
                Console.WriteLine(tarefa.Id + ". " + tarefa.Descricao);
            }
        }

        static List<Tarefa> ExcluirTarefa(List<Tarefa> listaDeTarefas)
        {
            if (!listaDeTarefas.Any())
            {
                Console.WriteLine("Não existe nenhuma tarefa para ser excluída." + Environment.NewLine);
            }
            else
            {
                Console.WriteLine("Qual tarefa deseja excluir?");
                var idExclusao = Convert.ToInt32(Console.ReadLine());

                if (!listaDeTarefas.Any(tarefa => tarefa.Id == idExclusao))
                {
                    Console.WriteLine("A tarefa que você quer excluir não existe." + Environment.NewLine);
                }
                else
                {
                    foreach (var tarefaExclusao in listaDeTarefas.ToList())
                    {
                        if (tarefaExclusao.Id == idExclusao)
                        {
                            listaDeTarefas.Remove(tarefaExclusao);
                        }
                    }
                }
            }

            return listaDeTarefas;
        }

        static List<Tarefa> EditarTarefa(List<Tarefa> listaDeTarefas)
        {
            if (!listaDeTarefas.Any())
            {
                Console.WriteLine("Não existe nenhuma tarefa para ser editada." + Environment.NewLine);
            }
            else
            {
                Console.WriteLine("Qual tarefa deseja editar?");
                var idEdicao = Convert.ToInt32(Console.ReadLine());

                if (!listaDeTarefas.Any(tarefa => tarefa.Id == idEdicao))
                {
                    Console.WriteLine("A tarefa que você quer editar não existe." + Environment.NewLine);
                }
                else
                {
                    foreach (var tarefaEdicao in listaDeTarefas)
                    {
                        if (tarefaEdicao.Id == idEdicao)
                        {
                            Console.WriteLine("Qual a nova descrição da tarefa?");
                            tarefaEdicao.Descricao = Console.ReadLine();
                        }
                    }
                }
            }

            return listaDeTarefas;
        }
    }
}