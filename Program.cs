 
using biblioteca.Classes;
using System.Threading.Channels;

namespace  biblioteca
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
            Console.WriteLine("Opcion ->");
            int option = int.Parse(Console.ReadLine());
            switch (option)
            {
                case 1:
                    _library.RegistrarBook();
                    break;
                case 2:
                    _library.ListarBooks();
                    break;
                case 3:
                    Console.WriteLine("Inserte el id del libro");
                    var id = int.Parse(Console.ReadLine());
                    _library.FindById(id);
                    id = 0;
                    break;
                case 4:
                    Console.WriteLine("Inserte el id del libro");
                    id = int.Parse(Console.ReadLine());
                    _library.EditarBook(id);
                    id = 0;
                    break;
                case 5:
                    Console.WriteLine("Inserte el id del libro");
                    id = int.Parse(Console.ReadLine());
                    _library.EliminarBook(id);
                    id = 0;
                    break;
                case 0:
                    _displayMenu = false;
                    break;
            }
        }

        public static void DisplayMenu()
        {
             

            Console.WriteLine("====== SISTEMA DE BIBLIOTECA ======");
            Console.WriteLine("1. Agregar libro\n2. Listar libros\n3. Buscar libro por ID\n4. Actualizar libro\n5. Eliminar libro\n0. Salir\n");
            Console.WriteLine("======= END MENU ======");
            InteractionMenu();
        }
        
        public static void InsertarBooks()
        {
            Book b1 = new Book("Clean Code", "Robert C. Martin", "9780132350884", 12);
            Book b2 = new Book("The Pragmatic Programmer", "Andrew Hunt", "9780135957059", 12);
            Book b3 = new Book("C# 12 in a Nutshell", "Joseph Albahari", "9781098147440", 12);
            Book b4 = new Book("Effective C#", "Bill Wagner", "9780134578962", 12);
            Book b5 = new Book("CLR via C#", "Jeffrey Richter", "9780735667457", 12);
            Book b6 = new Book("Head First Design Patterns", "Eric Freeman", "9780596007126", 12);
            Book b7 = new Book("Design Patterns", "Erich Gamma", "9780201633610", 12);
            Book b8 = new Book("Refactoring", "Martin Fowler", "9780134757599", 12);
            Book b9 = new Book("Domain-Driven Design", "Eric Evans", "9780321125217", 12);
            Book b10 = new Book("Clean Architecture", "Robert C. Martin", "9780134494166", 12);
            Book b11 = new Book("Pro ASP.NET Core", "Adam Freeman", "9781484279571", 12);
            Book b12 = new Book("Entity Framework Core in Action", "Jon P Smith", "9781617299963", 12);
            Book b13 = new Book("ASP.NET Core in Action", "Andrew Lock", "9781617294615", 12);
            Book b14 = new Book("Algorithms", "Robert Sedgewick", "9780321573513", 12);
            Book b15 = new Book("Data Structures and Algorithms", "Michael T. Goodrich", "9781118771334", 12);
            Book b16 = new Book("Introduction to Algorithms", "Thomas H. Cormen", "9780262046305", 12);
            Book b17 = new Book("Operating System Concepts", "Abraham Silberschatz", "9781119456339", 12);
            Book b18 = new Book("Computer Networks", "Andrew S. Tanenbaum", "9780132126953", 12);
            Book b19 = new Book("The Art of Computer Programming", "Donald E. Knuth", "9780201896831", 12);
            Book b20 = new Book("Programming Pearls", "Jon Bentley", "9780201657883", 12);
            _library.InsertarBook(b1);
            _library.InsertarBook(b2);
            _library.InsertarBook(b3);
            _library.InsertarBook(b4);
            _library.InsertarBook(b5);
            _library.InsertarBook(b6);
            _library.InsertarBook(b7);
            _library.InsertarBook(b8);
            _library.InsertarBook(b9);
            _library.InsertarBook(b10);
            //_library.InsertarBook(b11);
            //_library.InsertarBook(b12);
            //_library.InsertarBook(b13);
            //_library.InsertarBook(b14);
            //_library.InsertarBook(b15);
            //_library.InsertarBook(b16);
            //_library.InsertarBook(b17);
            //_library.InsertarBook(b18);
            //_library.InsertarBook(b19);
            //_library.InsertarBook(b20);
            Console.Clear();
        }
    }
};
 