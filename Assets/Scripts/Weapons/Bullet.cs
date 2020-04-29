using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float LifeTime;
    public float Speed;

    private int damage;
    private Vector3 direction;

    public void Shoot(Vector3 direction, int damage)
    {
        this.direction = direction;
        this.damage = damage;
        Destroy(this.gameObject, LifeTime);
    }

    private void FixedUpdate() =>
        transform.Translate(direction.normalized * Speed * Time.deltaTime);

    private void OnTriggerEnter(Collider other)
    {
        var tag = other.gameObject.tag;
        if (tag == "Grass") return;
        if (tag == "Enemy")
        {
            var enemy = other.GetComponent<IDamaged>();
            enemy.TakeDamage(damage);
        }
        Destroy(this.gameObject);
    }
}
