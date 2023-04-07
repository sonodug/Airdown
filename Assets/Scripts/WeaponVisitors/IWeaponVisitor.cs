public interface IWeaponVisitor
{
    void Visit(PRocket weapon);
    void Visit(DoubleRocketWeapon weapon);
    void Visit(ExplosionRocketWeapon weapon);
}