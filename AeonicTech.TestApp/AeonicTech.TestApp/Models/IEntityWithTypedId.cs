namespace AeonicTech.TestApp.Models
{
    public interface IEntityWithTypedId<TId>
    {
        TId Id { get; }
    }
}
