public class NormalDyingPolicy : IDyingPolicy
{
    public bool Died(float health)
    {
        return health <= 0;
    }
}