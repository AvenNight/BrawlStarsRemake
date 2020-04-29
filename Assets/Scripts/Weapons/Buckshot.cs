using UnityEngine;

public class Buckshot : MonoBehaviour
{
    [SerializeField]
    private Bullet bullet;
    [SerializeField]
    private int bulletCount;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float distance;
    [SerializeField]
    private float angle;

    private float lifeTime;

    public void SetShotSettings(Bullet bullet, int bulletCount, float speed, float distance, float angle)
    {
        this.bullet = bullet;
        this.bulletCount = bulletCount;
        this.speed = speed;
        this.distance = distance;
        this.angle = angle;
    }

    private void Start()
    {
        lifeTime = distance / speed;
        //bullet.GetComponent<Bullet>
        bullet.LifeTime = lifeTime;
    }

    public void Shoot(Vector3 direction)
    {
        for (int i = 0; i < bulletCount; i++)
        {
            var rndQuaternion = Quaternion.AngleAxis(Random.Range(-angle / 2, angle / 2), Vector3.up);
            var b = Instantiate(bullet, this.gameObject.transform.position + direction.normalized * 0.7f, Quaternion.Euler(direction));
            b.GetComponent<Bullet>().Shoot(rndQuaternion * direction, 10);
        }
    }
}
