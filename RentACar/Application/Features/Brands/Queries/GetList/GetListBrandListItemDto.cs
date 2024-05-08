namespace Application.Features.Brands.Queries.GetList
{
    //verikaynağımdaki bütün her şeyi kullanıcıya vermek istemiyoruz burada, neleri vermek istiyorsak onları vereceğiz
    public class GetListBrandListItemDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
