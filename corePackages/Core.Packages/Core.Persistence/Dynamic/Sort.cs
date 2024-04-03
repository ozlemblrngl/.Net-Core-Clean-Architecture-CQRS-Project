namespace Core.Persistence.Dynamic
{

    // Filtrelemede sort direction yapabiliriz. Yani a-z z-a,1-9, 9-1 vs şeklinde.
    public class Sort
    {
        public string Field { get; set; } // alana uyguayacağız bu sıralama işlemini

        public string Direction { get; set; } // hangi yönde asc mi desc mi belirtmek için

        public Sort()
        {
            Field = string.Empty;
            Direction = string.Empty;
        }

        public Sort(string field, string direction)
        {
            Field = field;
            Direction = direction;
        }

    }
}
