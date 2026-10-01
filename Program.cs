using biblioteca.Classes;

namespace biblioteca
{
    public class Program
    {
        private static Library _library;
        public static bool _displayMenu = true;

        public static void Main(string[] args)
        {
            _library = new Library();

            InsertarBooks();

            while (_displayMenu)
            {
                DisplayMenu();
            }
        }

        public static void InteractionMenu()
        {
            Console.Write("Opcion -> ");

            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    _library.ListarBooks();
                    break;

                case 2:
                    Console.Write("Inserte el id del libro: ");
                    int id = int.Parse(Console.ReadLine());

                    Console.Write(
                        "Inserte el id de la sucursal: "
                    );

                    int sucursal =
                        int.Parse(Console.ReadLine());

                    _library.ConsultarDisponibilidad(
                        id,
                        sucursal
                    );

                    break;

                case 3:
                    Console.Write("Inserte el id del libro: ");
                    id = int.Parse(Console.ReadLine());

                    Console.Write(
                        "Inserte el id de la sucursal: "
                    );

                    sucursal =
                        int.Parse(Console.ReadLine());

                    Console.Write(
                        "Inserte la cantidad a agregar: "
                    );

                    int cantidad =
                        int.Parse(Console.ReadLine());

                    _library.ActualizarDisponibilidad(
                        id,
                        sucursal,
                        cantidad
                    );

                    break;

                case 4:
                    Console.Write("Inserte el id del libro: ");
                    id = int.Parse(Console.ReadLine());

                    _library.TotalDisponibleBook(id);
                    break;

                case 5:
                    Console.Write(
                        "Inserte el id de la sucursal: "
                    );

                    sucursal =
                        int.Parse(Console.ReadLine());

                    _library.TotalInventarioSucursal(
                        sucursal
                    );

                    break;

                case 6:
                    _library.MostrarLibrosBajoInventario();
                    break;

                case 7:
                    Console.Write("Inserte el id del libro: ");
                    id = int.Parse(Console.ReadLine());

                    _library.SucursalMayorDisponibilidad(
                        id
                    );

                    break;

                case 0:
                    _displayMenu = false;
                    break;

                default:
                    Console.WriteLine(
                        "Opcion no valida."
                    );

                    break;
            }

            if (_displayMenu)
            {
                Console.WriteLine(
                    "\nPresione ENTER para continuar..."
                );

                Console.ReadLine();
                Console.Clear();
            }
        }

        public static void DisplayMenu()
        {
            Console.WriteLine(
                "====== INVENTARIO POR SUCURSAL ======\n"
            );

            Console.WriteLine(
                "1. Mostrar inventario completo\n" +
                "2. Consultar disponibilidad\n" +
                "3. Actualizar disponibilidad\n" +
                "4. Total disponible de un libro\n" +
                "5. Total de inventario por sucursal\n" +
                "6. Mostrar libros con bajo inventario\n" +
                "7. Sucursal con mayor disponibilidad\n" +
                "0. Salir\n"
            );

            Console.WriteLine(
                "======================================"
            );

            InteractionMenu();
        }

        public static void InsertarBooks()
        {
            Book b1 = new Book(
                "Clean Code",
                "Robert C. Martin",
                "9780132350884",
                5
            );

            Book b2 = new Book(
                "The Pragmatic Programmer",
                "Andrew Hunt",
                "9780135957059",
                2
            );

            Book b3 = new Book(
                "C# 12 in a Nutshell",
                "Joseph Albahari",
                "9781098147440",
                9
            );

            Book b4 = new Book(
                "Effective C#",
                "Bill Wagner",
                "9780134578962",
                3
            );

            Book b5 = new Book(
                "CLR via C#",
                "Jeffrey Richter",
                "9780735667457",
                8
            );

            _library.InsertarBook(b1, 0);
            _library.InsertarBook(
                new Book(
                    "Clean Code",
                    "Robert C. Martin",
                    "9780132350884",
                    3
                ),
                1
            );

            _library.InsertarBook(
                new Book(
                    "Clean Code",
                    "Robert C. Martin",
                    "9780132350884",
                    8
                ),
                2
            );

            _library.InsertarBook(b2, 0);

            _library.InsertarBook(
                new Book(
                    "The Pragmatic Programmer",
                    "Andrew Hunt",
                    "9780135957059",
                    7
                ),
                1
            );

            _library.InsertarBook(
                new Book(
                    "The Pragmatic Programmer",
                    "Andrew Hunt",
                    "9780135957059",
                    4
                ),
                2
            );

            _library.InsertarBook(b3, 0);

            _library.InsertarBook(
                new Book(
                    "C# 12 in a Nutshell",
                    "Joseph Albahari",
                    "9781098147440",
                    1
                ),
                1
            );

            _library.InsertarBook(
                new Book(
                    "C# 12 in a Nutshell",
                    "Joseph Albahari",
                    "9781098147440",
                    6
                ),
                2
            );

            _library.InsertarBook(b4, 0);

            _library.InsertarBook(
                new Book(
                    "Effective C#",
                    "Bill Wagner",
                    "9780134578962",
                    5
                ),
                1
            );

            _library.InsertarBook(
                new Book(
                    "Effective C#",
                    "Bill Wagner",
                    "9780134578962",
                    2
                ),
                2
            );

            _library.InsertarBook(b5, 0);

            _library.InsertarBook(
                new Book(
                    "CLR via C#",
                    "Jeffrey Richter",
                    "9780735667457",
                    4
                ),
                1
            );

            _library.InsertarBook(
                new Book(
                    "CLR via C#",
                    "Jeffrey Richter",
                    "9780735667457",
                    7
                ),
                2
            );

            Console.Clear();
        }
    }
}