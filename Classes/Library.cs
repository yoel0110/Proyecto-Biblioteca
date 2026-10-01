namespace biblioteca.Classes;

public class Library
{

    private Book[,] _books = new Book[20, 3];

    private string[] _sucusarNames =
    {
        "Itla Books",
        "UASD Books",
        "Central Books"
    };

    private int _total = 0;

    // O(1)
    public int Capacity() => _books.Length;

    // O(n^2)
    public void ListarBooks()
    {
        if (_total == 0)
        {
            Console.WriteLine("No hay libros registrados.");
            return;
        }

        Console.WriteLine("--- Libros registrados ---");

        for (int i = 0; i < _books.GetLength(0); i++)
        {
            for (int j = 0; j < _books.GetLength(1); j++)
            {
                if (_books[i, j] != null)
                {
                    Console.WriteLine(
                        $"{i + 1}. Titulo: {_books[i, j].Title} - " +
                        $"Sucursal: {_sucusarNames[j]} - " +
                        $"Id: {_books[i, j].Id} - " +
                        $"Cantidad: {_books[i, j].Quantity}"
                    );
                }
            }
        }

        Console.WriteLine("--------------------------");
    }

    // O(n^2)
    public (Book book, int indice, int sucursal) FindById(int id)
    {
        for (int i = 0; i < _books.GetLength(0); i++)
        {
            for (int j = 0; j < _books.GetLength(1); j++)
            {
                if (_books[i, j] != null &&
                    _books[i, j].Id == id)
                {
                    return (_books[i, j], i, j);
                }
            }
        }

        Console.WriteLine("Libro no encontrado.");

        return (null, -1, -1);
    }

    // O(n)
    public (Book book, int indice) FindById(
        int id,
        int sucursal)
    {
        for (int i = 0; i < _books.GetLength(0); i++)
        {
            if (_books[i, sucursal] != null &&
                _books[i, sucursal].Id == id)
            {
                return (_books[i, sucursal], i);
            }
        }

        return (null, -1);
    }

    // O(n)
    public void ConsultarDisponibilidad(
        int id,
        int sucursal)
    {
        (Book book, int indice) =
            FindById(id, sucursal);

        if (book != null)
        {
            Console.WriteLine(
                $"Libro: {_books[indice, sucursal].Title}"
            );

            Console.WriteLine(
                $"Sucursal: {_sucusarNames[sucursal]}"
            );

            Console.WriteLine(
                $"Cantidad disponible: " +
                $"{_books[indice, sucursal].Quantity}"
            );

            return;
        }

        Console.WriteLine(
            $"El libro no esta disponible en la sucursal " +
            $"{_sucusarNames[sucursal]}"
        );
    }

    // O(n^2)
    private (Book book, int indice) FindBook(Book book)
    {
        for (int i = 0; i < _books.GetLength(0); i++)
        {
            for (int j = 0; j < _books.GetLength(1); j++)
            {
                if (_books[i, j] != null &&
                    _books[i, j].Title == book.Title &&
                    _books[i, j].ISBN == book.ISBN)
                {
                    return (_books[i, j], i);
                }
            }
        }

        return (null, -1);
    }

    // O(n^2)
    public void RegistrarBook()
    {
        if (_total >= _books.GetLength(0))
        {
            Console.WriteLine(
                "Se ha alcanzado la capacidad máxima " +
                "de libros."
            );

            return;
        }

        Console.Write("Sucursal: ");
        int sucursal = int.Parse(Console.ReadLine()) - 1;

        if (sucursal < 0 ||
            sucursal >= _books.GetLength(1))
        {
            Console.WriteLine("Sucursal no válida.");
            return;
        }

        Console.Write("Título: ");
        string titulo = Console.ReadLine();

        Console.Write("Autor: ");
        string autor = Console.ReadLine();

        Console.Write("ISBN: ");
        string isbn = Console.ReadLine();

        Console.Write("Cantidad: ");
        int cantidad = int.Parse(Console.ReadLine());

        Book book = new Book(
            titulo,
            autor,
            isbn,
            cantidad
        );

        InsertarBook(book, sucursal);
    }

    // O(n^2)
    public void InsertarBook(
        Book book,
        int sucursal)
    {
        if (sucursal < 0 ||
            sucursal >= _books.GetLength(1))
        {
            Console.WriteLine("Sucursal no válida.");
            return;
        }

        (Book existente, int indice) =
            FindBook(book);

        if (existente != null)
        {
            if (_books[indice, sucursal] != null)
            {
                _books[indice, sucursal].AddQuantity(
                    book.Quantity
                );

                Console.WriteLine(
                    "El libro ya existe en esta sucursal. " +
                    "Se actualizó la cantidad."
                );

                return;
            }

            _books[indice, sucursal] = new Book(
                existente.Title,
                existente.Author,
                existente.ISBN,
                book.Quantity
            );

            Console.WriteLine(
                $"Libro registrado correctamente en " +
                $"{_sucusarNames[sucursal]}."
            );

            return;
        }

        if (_total >= _books.GetLength(0))
        {
            Console.WriteLine(
                "Se ha alcanzado la capacidad máxima " +
                "de libros."
            );

            return;
        }

        _books[_total, sucursal] = book;

        _total++;

        Console.WriteLine(
            $"Libro registrado correctamente en " +
            $"{_sucusarNames[sucursal]}."
        );
    }

    // O(n)
    public void ActualizarDisponibilidad(
        int id,
        int sucursal,
        int cantidad)
    {
        (Book book, int indice) =
            FindById(id, sucursal);

        if (book != null)
        {
            _books[indice, sucursal].AddQuantity(
                cantidad
            );

            Console.WriteLine(
                "Disponibilidad actualizada correctamente."
            );

            return;
        }

        Console.WriteLine("Libro no encontrado.");
    }

    // O(n^2)
    public void TotalDisponibleBook(int id)
    {
        int total = 0;

        for (int i = 0; i < _books.GetLength(0); i++)
        {
            for (int j = 0; j < _books.GetLength(1); j++)
            {
                if (_books[i, j] != null &&
                    _books[i, j].Id == id)
                {
                    total += _books[i, j].Quantity;
                }
            }
        }

        Console.WriteLine(
            $"Total disponible del libro: {total}"
        );
    }

    // O(n)
    public void TotalInventarioSucursal(
        int sucursal)
    {
        if (sucursal < 0 ||
            sucursal >= _books.GetLength(1))
        {
            Console.WriteLine("Sucursal no válida.");
            return;
        }

        int total = 0;

        for (int i = 0; i < _books.GetLength(0); i++)
        {
            if (_books[i, sucursal] != null)
            {
                total += _books[i, sucursal].Quantity;
            }
        }

        Console.WriteLine(
            $"Total de inventario en " +
            $"{_sucusarNames[sucursal]}: {total}"
        );
    }

    // O(n^2)
    public void MostrarLibrosBajoInventario()
    {
        Console.WriteLine(
            "--- Libros con bajo inventario ---"
        );

        for (int i = 0; i < _books.GetLength(0); i++)
        {
            for (int j = 0; j < _books.GetLength(1); j++)
            {
                if (_books[i, j] != null &&
                    _books[i, j].Quantity <= 3)
                {
                    Console.WriteLine(
                        $"Titulo: {_books[i, j].Title} - " +
                        $"Sucursal: {_sucusarNames[j]} - " +
                        $"Cantidad: {_books[i, j].Quantity}"
                    );
                }
            }
        }

        Console.WriteLine("--------------------------");
    }

    // O(n^2)
    public void SucursalMayorDisponibilidad(
        int id)
    {
        int mayorCantidad = -1;
        int mayorSucursal = -1;

        for (int j = 0;
             j < _books.GetLength(1);
             j++)
        {
            for (int i = 0;
                 i < _books.GetLength(0);
                 i++)
            {
                if (_books[i, j] != null &&
                    _books[i, j].Id == id)
                {
                    if (_books[i, j].Quantity >
                        mayorCantidad)
                    {
                        mayorCantidad =
                            _books[i, j].Quantity;

                        mayorSucursal = j;
                    }

                    break;
                }
            }
        }

        if (mayorSucursal == -1)
        {
            Console.WriteLine("Libro no encontrado.");
            return;
        }

        Console.WriteLine(
            $"Sucursal con mayor disponibilidad: " +
            $"{_sucusarNames[mayorSucursal]} - " +
            $"Cantidad: {mayorCantidad}"
        );
    }
    //// O(n)
    //public void EliminarBook(int id, int sucursar)
    //{
    //    var (book, indice) = FindById(id);

    //    if (book == null)
    //    {
    //        return;
    //    }

    //    for (int i = indice; i < _last - 1; i++)
    //    {
    //        _books[i] = _books[i + 1];
    //    }

    //    _books[_last - 1] = null;

    //    _last--;

    //    Console.WriteLine("Libro eliminado correctamente.");
    //}
}