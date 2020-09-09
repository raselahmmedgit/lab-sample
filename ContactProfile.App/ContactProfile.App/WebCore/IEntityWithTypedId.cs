namespace ContactProfile.App.WebCore
{
    public interface IEntityWithTypedId<TId>
    {
        TId Id { get; }
    }
}
