﻿namespace Core.Persistence.Repositories
{
    public class Entity<TId>
    {
        public TId Id { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }

        public Entity()
        {
            Id = default; // id verilmezse defaultu neyse o olsun; integersa 0 olsun mesela.

        }

        public Entity(TId id)
        {
            Id = id;
        }

    }
}