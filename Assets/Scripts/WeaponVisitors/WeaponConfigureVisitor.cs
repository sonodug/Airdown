using UnityEngine;
using Zenject;

public class WeaponConfigureVisitor : IWeaponVisitor
{
    private Player _player;

    public void Visit(PRocket weapon)
    {
        _player.ConfigureRocketWeapon();
    }

    public void Visit(DoubleRocketWeapon weapon)
    {
        _player.ConfigureByDoubleRocketWeapon();
    }

    public void Visit(ExplosionRocketWeapon weapon)
    {
        _player.ConfigureByExplosionRocketWeapon();
    }

    public void Init(Player player)
    {
        _player = player;
    }
}