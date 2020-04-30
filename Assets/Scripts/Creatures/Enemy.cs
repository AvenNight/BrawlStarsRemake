using System;
using UnityEngine;

public class Enemy : Creature
{
    public float UpdateTime;
    public float AggroDistance;
    public float AttackRange;

    [SerializeField] private MeleeAIWeapon weapon;

    private ObjectsFinder playersFinder;

    void Start()
    {
        weapon.Cooldown = attackSpeed;
        weapon.damage = attack;

        InvokeRepeating("UpdateEnemy", UpdateTime, UpdateTime);
    }

    void UpdateEnemy()
    {
        playersFinder = new CreatureFinder(this.gameObject, "Player");
        if (playersFinder.Objects.Count == 0)
        {
            agent.isStopped = true;
            weapon.autoAttack = false;
            return;
        }
        var direction = playersFinder.Direction;
        AttackAI(direction);
        if (playersFinder.DistanceToNearest < AggroDistance)
        {
            agent.SetDestination(playersFinder.NearestObject.transform.position);
            agent.isStopped = false;
        }
        else
            agent.isStopped = true;
    }


    private void AttackAI(Vector3 direction)
    {
        var ray = new Ray(this.transform.position, direction);
        bool hitted = Physics.Raycast(ray, out RaycastHit hit, AttackRange);
        if (hitted && hit.collider.tag == "Player")
        {
            weapon.autoAttack = true;
            weapon.AttackedCreature = hit.collider.GetComponent<Creature>();
            //Debug.DrawRay(this.transform.position, direction, new Color(0, 1, 0, 0.1f));
        }
        else
        {
            weapon.autoAttack = false;
            //Debug.DrawRay(this.transform.position, direction, new Color(1, 0, 0, 0.3f));
        }
    }
}