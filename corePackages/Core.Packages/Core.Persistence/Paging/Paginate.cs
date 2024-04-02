namespace Core.Persistence.Paging
{
    public class Paginate<T>
    {
        public Paginate()
        {
            Items = Array.Empty<T>(); // ilk etapta boş bir eleman olarak oluşturabiliriz.
        }

        public int Size { get; set; }
        public int Index { get; set; }
        public int Count { get; set; } // kayıt sayısı
        public int Pages { get; set; }
        public IList<T> Items { get; set; }
        public bool HasPrevious => Index > 0;
        public bool HasNext => Index + 1 < Pages; // diyelim ki 10 sayfa var, eğer 9. index'teyse zaten 10. sayfadadır, o nedenle index+1 yaptık ve sonraki sayfa yok demektir.

    }
}
