internal class Program
{
    private static void Main(string[] args)
    {
        LinqQueries queries = new LinqQueries();
        //ImprimirValores(queries.AllCollection());
        //ImprimirValores(queries.LibrosDespues2000());
        //ImprimirValores(queries.GetBooksTake());
        //ImprimirValores(queries.GetBooksSkipTerceyCuarto());
        // Console.WriteLine($"Total de libros que tienen entre 200 y 500 paginas {queries.GetBooksCount()}");
        Console.WriteLine($"Fecha de publicacion menor {queries.GetBooksDatePublishMax()}");
        //ImprimirValores(queries.GetBooksListDatePublishMinor());
    }

    private static void ImprimirValores(IEnumerable<Book> books)
    {
        int registros = 0;
        Console.Clear();
        Console.WriteLine("{0,-70} {1,7} {2,20}\n", "Titulo", "N. Paginas", "Fecha publicacion");
        foreach (Book book in books)
        {
            registros += 1;
            Console.WriteLine("{0,-70} {1,7} {2,20}", book.Title, book.PageCount, book.PublishedDate.ToShortDateString());
            if (registros % 10 == 0)
            {
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("{0,-70} {1,7} {2,20}\n", "Titulo", "N. Paginas", "Fecha publicacion");
            }
        }
    }
}