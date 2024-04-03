namespace Core.Persistence.Dynamic
{
    // içinde filterlar ve sortlar olan yapıdır ve linq e git bu queryi çalıştır diyeceğiz
    // o nedenle böyle bir nesne oluşturmak üzere bu classı açıyoruz.
    // burayı yaptıktan sonra artık gidip DynamicQuery'i repository'lerimizde kullanabiliriz.
    public class DynamicQuery
    {
        public IEnumerable<Sort>? Sort { get; set; } // sıralama değeri. Sortları çoğul yaptık çünkü birden fazla sort olabilir.

        public Filter? Filter { get; set; } // burada neden tekil çünkü filter classındaki mimari bir filtrenin üstüne birden fazla filtre uygulanacak şekilde düzenlendi yani filtrenin kendi filtreleri düzenlenebiliyor, buraya o nedenle tekil yaptık.

        public DynamicQuery()
        {

        }
        public DynamicQuery(IEnumerable<Sort>? sort, Filter? filter)
        {
            Filter = filter;
            Sort = sort;
        }
    }
}
