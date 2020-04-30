using UnityEngine;

public class MeleeAIWeapon : MonoBehaviour
{
    public bool autoAttack { get; set; }
    public Vector3 Direction { get; set; }
    public int damage { get; set; }
    public int Damage => Random.Range(1, damage * 2);
    public float Cooldown { get; set; }

    public Creature AttackedCreature { get; set; }

    private void Start() => InvokeRepeating("Attacking", Cooldown, Cooldown);

    protected void Attacking()
    {
        if (autoAttack)
            Attack();
    }

    protected void Attack() => AttackedCreature.TakeDamage(this.Damage);
}