namespace Core.Persistence.Repositories
{
    public interface IEntityTimestamps
    {
        // interface olabilmesi için başındaki publicleri siliyoruz propların
        DateTime CreatedDate { get; set; }
        DateTime? UpdatedDate { get; set; }
        DateTime? DeletedDate { get; set; }
    }
}
