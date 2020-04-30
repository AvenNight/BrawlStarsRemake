using System.Collections.Generic;
using UnityEngine;

public class Shotgun : RangeWeapon
{
    [SerializeField] private Bullet bullet;
    [SerializeField] private List<string> enemyTags;
    [SerializeField] private int damage;
    [SerializeField] private bool isRndDmg;
    [SerializeField] private int bulletCount;
    [SerializeField] private float speed;

    private void Start()
    {
        bullet.Damage = damage;
        bullet.IsRndDmg = isRndDmg;
        bullet.Distance = distance;
        bullet.Speed = speed;
        bullet.EnemyTags = enemyTags;
        curAmmo = maxAmmo;
    }

    public override void Shoot(Vector3 direction)
    {
        if (curAmmo <= 0) return;
        for (int i = 0; i < bulletCount; i++)
        {
            var rndQuaternion = Quaternion.AngleAxis(Random.Range(-angle / 2, angle / 2), Vector3.up);
            var b = Instantiate(bullet, this.gameObject.transform.position + direction.normalized * 0.55f, Quaternion.Euler(direction));
            b.GetComponent<Bullet>().Shoot(rndQuaternion * direction);
        }
        base.Shoot(direction);
    }
}