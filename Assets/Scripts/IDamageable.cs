public interface IDamageable
{
    public float durability { get; set; }
    void TakeDamage(float damageTaken);
}
