using System.Linq;

public class LinqQueries{
    List<Book> lstBooks = new List<Book>();
    public LinqQueries(){
        using(StreamReader reader = new StreamReader("books.json")){
            string json = reader.ReadToEnd();
            this.lstBooks = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(json,new System.Text.Json.JsonSerializerOptions(){PropertyNameCaseInsensitive = true}) ?? new List<Book>();
        }
    }
    public IEnumerable<Book> AllCollection(){
        return lstBooks;
    }
    public IEnumerable<Book> LibrosDespues2000(){
        //Extension method
        //return lstBooks.Where(book => book.PublishedDate.Year > 2000);
        return from book in lstBooks where book.PublishedDate.Year >200 select book;
    }
    public IEnumerable<Book> LibrosMas250Pag(){
        return from book in lstBooks 
                where book.PageCount > 250 
                && (book.Title ?? String.Empty).Contains("in Action") 
                select book;
    }
    public IEnumerable<Book> ListarBookConStatus(){
        return from book in lstBooks
                where book.Status != String.Empty
                select book;
    }
    public bool ValidarStatus(){
        return lstBooks.All(book => book.Status != String.Empty);
    }
    public bool ValidarFechaPub(){
        return lstBooks.Any(book => book.PublishedDate.Year == 2005);
    }
    public IEnumerable<Book> GetBooksPython(){
        return lstBooks.Where(
            book => (book.Categories ?? Array.Empty<string>()).Contains("Python"));
    }
    public IEnumerable<Book> GetBooksSortAsc(){
        return lstBooks.Where(
            book => (book.Categories ?? Array.Empty<string>()).Contains("Java"))
            .OrderBy(book => book.Title);
    }
    
    public IEnumerable<Book> GetBooksSortDsc(){
        return lstBooks.Where(
            book => book.PageCount>450)
            .OrderByDescending(book => book.PageCount);
    }

    public IEnumerable<Book> GetBooksTake(){
        return lstBooks
        .Where(book => (book.Categories ?? Array.Empty<string>()).Contains("Java"))
        .OrderByDescending(book => book.PublishedDate).Take(3);
    
    }
    //Muestra los ultimos tres libro
    public IEnumerable<Book> GetBooksTakeLast(){
        return lstBooks
        .Where(book => (book.Categories ?? Array.Empty<string>()).Contains("Java"))
        .OrderBy(book => book.PublishedDate).TakeLast(3);
    
    }
    public IEnumerable<Book> GetBooksSkipTerceyCuarto(){
        return lstBooks
        .Where(book => book.PageCount > 400)
        .Take(4)
        .Skip(2);
    }
    public IEnumerable<Book> GetBooksSelect(){
        return lstBooks.Take(3)
        .Select(book => new Book{ Title = book.Title,PageCount =book.PageCount });
    }
    public int GetBooksCount(){
        return lstBooks
        .Count(book => book.PageCount>=200 && book.PageCount<=500);
    }
    public long GetBooksLongCount(){
        return lstBooks
        .LongCount(book => book.PageCount>=200 && book.PageCount<=500);
    }
    public DateTime GetBooksDatePublishMinor(){
        return lstBooks.Min(book => book.PublishedDate);
    }
    public DateTime GetBooksDatePublishMax(){
        return lstBooks.Max(book => book.PublishedDate);
    }
    public IEnumerable<Book> GetBooksListDatePublishMinor(){
        var fechaPublicacionMinima = lstBooks.Min(libro => libro.PublishedDate);
        return lstBooks.Where(libro => libro.PublishedDate == fechaPublicacionMinima);
    }

}
