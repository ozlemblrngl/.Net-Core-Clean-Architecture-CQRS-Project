namespace Core.Persistence.Dynamic
{
    // filtreye konu işlemler
    // dynamic sorgu yapabilmek için System.Linq.Dynamic.Core nuget paketini kullanıyoruz. 
    public class Filter
    {
        public string Field { get; set; } // filtre hangi alan üzerinde çalışacak örn yakıt tipi ne?

        public string? Value { get; set; } // bunun değeri ne? field'i verip değer vermeyebilir o yüzden nullable

        public string Operator { get; set; } // Nedir bu operator? bu field üzerinde veri tipine göre eşittir olabilir içinde geçen olabilir, sayısal değerlerse büyüktür küçüktür vs olabilir

        public string? Logic { get; set; } // birden fazla alan üzerinde çalışma yapacağız ve aralarında şu şartı sağlayan vs yani and or logici sağlamak için kısaca logic kısımlar için kullanılır.

        public IEnumerable<Filter> Filters { get; set; } // birden fazla filtrem de olabilir. Filtre listesi için kullanılır.Bir filtreye başka filtrele uygulayabiliyoruz. Zincirleme filtreler(İçiçe filtreler) var burada filtrenin kendi içindeki filtreleri  

        //aşağıdakiler sırf zenginleştirerek kullanmak içindir.
        public Filter()
        {
            Field = string.Empty;
            Operator = string.Empty;
        }

        // eğer c# ta kullanılan bir keywordse ve biz o kelimeyi değişken olarak kullanmak istiyorsak başına @ koyarak kullanabiliriz.
        // örn operator keywordur ve biz burada değişken olarak kullanmak istediğimiz için @operator şeklinde yazdık.
        public Filter(string field, string @operator)
        {
            Field = field;
            Operator = @operator;
        }
    }

}
