namespace Core.Persistence.Repositories
{

    // Bazen raporlar istenebilir ve predicate le sorgulama yeterli olmayabilir.
    // veritabanına sql sorgusu atabilmemizi sağlar bu repo.
    // İlgili domain nesnesi için query atabiliriz böylece.
    // hem IRepository'de hem de IAsyncRepository'de implemente ederek kullanabiliriz böylece
    public interface IQuery<T>
    {
        IQueryable<T> Query();
    }
}
