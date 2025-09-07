namespace marketList;
public class Program
{
    public static void Main()
    {
        List<string> storeListName = new List<string>();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("CRIADOR DE LISTA DE MERCADO");
            Console.Write("\n1. Criar nova lista\n2. Modificar lista\n3. Vizualizar lista\n4. Sair\n\nDigite uma opção: ");
            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    List<string> list = new List<string>();
                    Console.Write("\nDê um nome para a lista: ");
                    string listName = Console.ReadLine().ToUpper();
                    storeListName.Add(listName);

                    string path = $@"C:\Users\vitor\OneDrive\Área de Trabalho\Listas de Mercado\{listName}.Doc";

                    Console.Write("\nDigite um item a ser adicionado: ");

                    list.Add(Console.ReadLine());
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("\nDeseja adicionar mais um item? (SIM/NAO)");
                        string optionString = Console.ReadLine().ToUpper();

                        if (optionString == "NAO")
                        {
                            System.IO.File.WriteAllText(path, string.Join(Environment.NewLine, list));
                            Console.WriteLine("\nA lista foi enviada para pasta Listas na Área de Trabalho.");
                            Console.ReadKey();
                            break; 
                        }
                        else if (optionString == "SIM")
                        {
                            Console.Write("\nDigite um item a ser adicionado: ");
                            list.Add(Console.ReadLine());
                        }
                        else
                        {
                            Console.WriteLine("\nDigite uma opção válida! ");
                            Console.ReadKey();
                        }
                    }
                    break;

                case 2:
                    Console.Write("\nDigite o nome da lista que deseja modificar: ");
                    string checkListName = Console.ReadLine().ToUpper();

                    if (storeListName.Contains(checkListName))
                    {
                        List<string> addList = new List<string>();
                        Console.Write("\nDigite um item a ser adicionado: ");
                        addList.Add(Console.ReadLine());

                        while (true)
                        {
                            Console.WriteLine("\nDeseja adicionar mais um item? (SIM/NAO)");                                                                                                                                                                                                                                                        
                            string optionString = Console.ReadLine().ToUpper();

                            if (optionString == "NAO")
                            {
                                string modifyPath = $@"C:\Users\vitor\OneDrive\Área de Trabalho\Listas de Mercado\{checkListName}.Doc";
                                System.IO.File.AppendAllText(modifyPath, Environment.NewLine + string.Join(Environment.NewLine, addList));
                                Console.WriteLine("\nA lista foi atualizada.");
                                Console.ReadKey();
                                break;                                                                                                      
                            }
                            else if (optionString == "SIM")
                            {
                                Console.Write("\nDigite um item a ser adicionado: ");
                                addList.Add(Console.ReadLine());
                            }
                            else
                            {
                                Console.WriteLine("\nDigite uma opção válida! ");
                                Console.ReadKey();
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nLista não encontrada!");
                        Console.ReadKey();
                    }
                    break;

                case 3:
                    Console.Write("Digite o nome da lista desejada: ");
                    checkListName = Console.ReadLine().ToUpper();

                    if (storeListName.Contains(checkListName))
                    {
                        string viewPath = $@"C:\Users\vitor\OneDrive\Área de Trabalho\Listas de Mercado\{checkListName}.Doc";

                        if (File.Exists(viewPath))
                        {
                            string listContent = File.ReadAllText(viewPath);
                            Console.WriteLine($"\nConteúdo da lista {checkListName}:\n");
                            Console.WriteLine(listContent);
                        }
                        else
                        {
                            Console.WriteLine("Arquivo da lista não encontrado na pasta.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Lista não encontrada no sistema!");
                    }

                    Console.ReadKey();
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
}