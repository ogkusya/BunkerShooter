public interface IDamageable
{
    void TakeDamage(int damage, DamageableType damageType = DamageableType.Player);
}