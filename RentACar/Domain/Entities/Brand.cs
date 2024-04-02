using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Brand : Entity<Guid>
{

    public string Name { get; set; }

    //kullanım kolaylığı sağlamak üzere aşağıdaki constructor ları yapıyoruz

    public Brand()
    {

    }

    public Brand(Guid id, string name)
    {
        Id = id;

        Name = name;
    }


}
