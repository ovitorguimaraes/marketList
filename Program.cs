namespace marketList;

using System;
using System.Collections.Generic;
using System.IO;

public class ListaDeMercado
{
    public string Nome { get; private set; }
    public List<string> Itens { get; private set; }

    public ListaDeMercado(string nome)
    {
        Nome = nome.ToUpper();
        Itens = new List<string>();
    }

    public void AdicionarItem(string item)
    {
        Itens.Add(item);
    }

    public void Salvar(string pasta)
    {
        string caminho = Path.Combine(pasta, $"{Nome}.doc");
        File.WriteAllText(caminho, string.Join(Environment.NewLine, Itens));
    }

    public void Atualizar(string pasta, List<string> novosItens)
    {
        string caminho = Path.Combine(pasta, $"{Nome}.doc");
        File.AppendAllText(caminho, Environment.NewLine + string.Join(Environment.NewLine, novosItens));
        Itens.AddRange(novosItens);
    }

    public void Mostrar(string pasta)
    {
        string caminho = Path.Combine(pasta, $"{Nome}.doc");
        if (File.Exists(caminho))
        {
            string conteudo = File.ReadAllText(caminho);
            Console.WriteLine($"\nConteúdo da lista {Nome}:\n");
            Console.WriteLine(conteudo);
        }
        else
        {
            Console.WriteLine("Arquivo da lista não encontrado na pasta.");
        }
    }
}

public class GerenciadorDeListas
{
    private List<ListaDeMercado> listas = new List<ListaDeMercado>();
    private string pasta = @"C:\Users\vitor\OneDrive\Área de Trabalho\Listas de Mercado";

    public void Iniciar()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("CRIADOR DE LISTA DE MERCADO");
            Console.Write("\n1. Criar nova lista\n2. Modificar lista\n3. Visualizar lista\n4. Sair\n\nDigite uma opção: ");
            
            int opcao;
            if (!int.TryParse(Console.ReadLine(), out opcao))
            {
                Console.WriteLine("Opção inválida!");
                Console.ReadKey();
                continue;
            }

            switch (opcao)
            {
                case 1:
                    CriarLista();
                    break;
                case 2:
                    ModificarLista();
                    break;
                case 3:
                    VisualizarLista();
                    break;
                case 4:
                    Console.WriteLine("Falo chefe!");
                    Console.ReadKey();
                    return;
                default:
                    Console.WriteLine("Opção inválida!");
                    Console.ReadKey();
                    break;
            }
        }
    }

    private void CriarLista()
    {
        Console.Write("\nDê um nome para a lista: ");
        string nome = Console.ReadLine();
        ListaDeMercado lista = new ListaDeMercado(nome);
        listas.Add(lista);

        Console.Write("\nDigite um item a ser adicionado: ");
        lista.AdicionarItem(Console.ReadLine());

        while (true)
        {
            Console.Clear();
            Console.WriteLine("\nDeseja adicionar mais um item? (SIM/NAO)");
            string resposta = Console.ReadLine().ToUpper();

            if (resposta == "NAO")
            {
                lista.Salvar(pasta);
                Console.WriteLine("\nA lista foi enviada para pasta Listas na Área de Trabalho.");
                Console.ReadKey();
                break;
            }
            else if (resposta == "SIM")
            {
                Console.Write("\nDigite um item a ser adicionado: ");
                lista.AdicionarItem(Console.ReadLine());
            }
            else
            {
                Console.WriteLine("\nDigite uma opção válida!");
                Console.ReadKey();
            }
        }
    }

    private void ModificarLista()
    {
        Console.Write("\nDigite o nome da lista que deseja modificar: ");
        string nome = Console.ReadLine().ToUpper();
        ListaDeMercado lista = listas.Find(l => l.Nome == nome);

        if (lista != null)
        {
            List<string> novosItens = new List<string>();
            Console.Write("\nDigite um item a ser adicionado: ");
            novosItens.Add(Console.ReadLine());

            while (true)
            {
                Console.WriteLine("\nDeseja adicionar mais um item? (SIM/NAO)");
                string resposta = Console.ReadLine().ToUpper();

                if (resposta == "NAO")
                {
                    lista.Atualizar(pasta, novosItens);
                    Console.WriteLine("\nA lista foi atualizada.");
                    Console.ReadKey();
                    break;
                }
                else if (resposta == "SIM")
                {
                    Console.Write("\nDigite um item a ser adicionado: ");
                    novosItens.Add(Console.ReadLine());
                }
                else
                {
                    Console.WriteLine("\nDigite uma opção válida!");
                    Console.ReadKey();
                }
            }
        }
        else
        {
            Console.WriteLine("\nLista não encontrada!");
            Console.ReadKey();
        }
    }

    private void VisualizarLista()
    {
        Console.Write("\nDigite o nome da lista desejada: ");
        string nome = Console.ReadLine().ToUpper();
        ListaDeMercado lista = listas.Find(l => l.Nome == nome);

        if (lista != null)
        {
            lista.Mostrar(pasta);
        }
        else
        {
            Console.WriteLine("Lista não encontrada no sistema!");
        }

        Console.ReadKey();
    }
}

public class Program
{
    public static void Main()
    {
        GerenciadorDeListas gerenciador = new GerenciadorDeListas();
        gerenciador.Iniciar();
    }
}