namespace biblioteca.Classes;

public class Library
{
    private Book[] _books = new Book[20];
    private int _last = 0;

    // O(1)
    public int Capacity() => _books.Length;

    // O(n)
    public void ListarBooks()
    {
        Console.WriteLine("--- Libros registrados ---");

        for (int i = 0; i < _last; i++)
        {
            if (_books[i] != null)
            {
                Console.WriteLine($"{i + 1}. {_books[i].Title}");
            }
        }

        Console.WriteLine("--------------------------");
    }

    // O(n)
    public (Book book, int indice) FindById(int id)
    {
        for (int i = 0; i < _last; i++)
        {
            if (_books[i] != null && _books[i].Id == id)
            {
                Console.WriteLine(
                    "[--------------- Información del libro ------------]"
                );

                Console.WriteLine(
                    $"Id: {_books[i].Id}\n" +
                    $"Título: {_books[i].Title}\n" +
                    $"Autor: {_books[i].Author}\n" +
                    $"ISBN: {_books[i].ISBN}\n" +
                    $"Cantidad: {_books[i].Quantity}"
                );

                Console.WriteLine(
                    "----------------------------------------------------"
                );

                return (_books[i], i);
            }
        }

        Console.WriteLine("Libro no encontrado");
        return (null, -1);
    }

    // O(n)
    private Book FindBook(Book book)
    {
        for (int i = 0; i < _last; i++)
        {
            if (_books[i] != null &&
                _books[i].Title == book.Title &&
                _books[i].ISBN == book.ISBN)
            {
                return _books[i];
            }
        }

        return null;
    }

    // O(n)
    public void RegistrarBook()
    {
        if (_last >= _books.Length)
        {
            Console.WriteLine(
                "Se ha alcanzado la capacidad máxima del almacén."
            );
            return;
        }

        Console.Write("Título: ");
        var titulo = Console.ReadLine();

        Console.Write("Autor: ");
        var autor = Console.ReadLine();

        Console.Write("ISBN: ");
        var isbn = Console.ReadLine();

        Console.Write("Cantidad: ");
        var cantidad = int.Parse(Console.ReadLine());

        Book book = new Book(
            titulo,
            autor,
            isbn,
            cantidad
        );

        InsertarBook(book);
    }

    // O(n) por FindBook()
    public void InsertarBook(Book book)
    {
        if (_last >= _books.Length)
        {
            Console.WriteLine(
                "Se ha alcanzado la capacidad máxima del almacén."
            );
            return;
        }

        Book existente = FindBook(book);

        if (existente != null)
        {
            existente.AddQuantity(book.Quantity);

            Console.WriteLine(
                "El libro ya existe. Se actualizó la cantidad."
            );

            return;
        }

        _books[_last] = book;
        _last++;

        Console.WriteLine("Libro registrado correctamente.");
    }

    // O(n)
    public void EditarBook(int id)
    {
        var (book, _) = FindById(id);

        if (book == null)
        {
            return;
        }

        Console.WriteLine($"{book.Id} - {book.Title}");

        Console.Write(
            $"Título del libro: {book.Title}. " +
            "Presione Enter para no editar: "
        );

        var nombre = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(nombre))
        {
            book.UpdateTitle(nombre);
        }

        Console.Write(
            $"ISBN del libro: {book.ISBN}. " +
            "Presione Enter para no editar: "
        );

        var isbn = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(isbn))
        {
            book.UpdateISBN(isbn);
        }

        Console.Write(
            $"Autor del libro: {book.Author}. " +
            "Presione Enter para no editar: "
        );

        var autor = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(autor))
        {
            book.UpdateAuthor(autor);
        }

        Console.Write(
            $"Stock del libro: {book.Quantity}. " +
            "Presione Enter para no editar: "
        );

        var stockInput = Console.ReadLine();

        if (int.TryParse(stockInput, out int stock) && stock >= 0)
        {
            book.UpdateQuantity(stock);
        }

        Console.WriteLine("Libro actualizado correctamente.");
    }

    // O(n)
    public void EliminarBook(int id)
    {
        var (book, indice) = FindById(id);

        if (book == null)
        {
            return;
        }

        for (int i = indice; i < _last - 1; i++)
        {
            _books[i] = _books[i + 1];
        }

        _books[_last - 1] = null;

        _last--;

        Console.WriteLine("Libro eliminado correctamente.");
    }
}