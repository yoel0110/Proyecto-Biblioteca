namespace biblioteca.Classes;

public class Book
{
    private static int _id; 
    public int Id { get; private set; }
    public string Title { get; private set; }
    public string Author { get; private set; }
    public string ISBN { get; private set; }
    public int Quantity { get; private set; }

    public Book(string title, string author, string isbn,  int quantity )
    {
        Book._id = _id + 1;
        Id = _id;
        Title = title;
        Author = author;
        ISBN =  isbn;
        Quantity = quantity;
    }

    public void UpdateTitle(string newTitle)
    {
        if(string.IsNullOrWhiteSpace(newTitle))
            throw new ArgumentNullException($"Error {nameof(newTitle)}");
        
        var oldTitle = Title;
        Title = newTitle;
        Console.WriteLine($"Titulo actualizado de: {oldTitle} to : {newTitle}");
    }

    public void UpdateAuthor(string newAuthor)
    {
        if(string.IsNullOrWhiteSpace(newAuthor))
            throw new ArgumentNullException($"Error {nameof(newAuthor)}");
        
        var oldAuthor = Author;
        Author = newAuthor;
        Console.WriteLine($"Autor actualizado de: {oldAuthor} to : {newAuthor}");
    }

    public void UpdateISBN(string newISBN)
    {
        if(string.IsNullOrWhiteSpace(newISBN))
            throw new ArgumentNullException($"Error {nameof(newISBN)}");
        var oldISBN = ISBN;
        ISBN = newISBN;
        Console.WriteLine($"ISB actualizado de: {oldISBN} to : {newISBN}");
    }

    public void UpdateQuantity(int newQuantity)
    {
        if(newQuantity < 0)
            throw new ArgumentOutOfRangeException($"Error {nameof(newQuantity)}");
        var oldQuantity =  Quantity;
        Quantity = Quantity;
        Console.WriteLine($"{Title} stock actualizado de: {oldQuantity} to : {newQuantity}");
    }

    public void AddQuantity(int newQuantity)
    {
        if(newQuantity < 0)
            throw new ArgumentOutOfRangeException($"Error {nameof(newQuantity)}");
        var oldQuantity = Quantity;
        Quantity += newQuantity;
        Console.WriteLine($"Stock actualizado de: {oldQuantity} to : {Quantity}");
    }
}