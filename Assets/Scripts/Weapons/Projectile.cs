using UnityEngine;

// OLD TEMP
public class Projectile : MonoBehaviour
{
    protected int damage;
    protected float lifeTime;
    protected float speed;

    protected Vector3 direction;

    public virtual void SetSettings(int damage, float lifeTime, float speed)
    {
        this.damage = damage;
        this.lifeTime = lifeTime;
        this.speed = speed;
    }

    public virtual void Shoot(Vector3 direction)
    {
        this.direction = direction;
        Destroy(this.gameObject, lifeTime);
    }

    protected virtual void FixedUpdate() =>
        transform.Translate(direction.normalized * speed * Time.deltaTime);

    protected virtual void OnTriggerEnter(Collider other) => Destroy(this.gameObject);
}