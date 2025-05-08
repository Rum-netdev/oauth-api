namespace OAuthSystem.Data.Entities.Shared
{
    public interface IBaseEntity<TKey>
    {
        TKey Id { get; set; }
    }
}
