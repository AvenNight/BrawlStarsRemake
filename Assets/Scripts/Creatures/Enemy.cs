using System;
using UnityEngine;

public class Enemy : Creature
{
    public float UpdateTime;
    public float AggroDistance;
    public float AttackRange;

    [SerializeField] private RangeWeapon curWeapon;

    private ObjectsFinder playersFinder;

    void Start()
    {
        InvokeRepeating("EnemyAI", UpdateTime, UpdateTime);
    }
    private void EnemyAI()
    {
        playersFinder = new CreatureFinder(this.gameObject, "Player");
        if (playersFinder.Objects.Count == 0)
        {
            agent.isStopped = true;
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
        if (hitted && (hit.collider.tag == "Player" || hit.collider.tag == "Grass"))
            curWeapon.Shoot(direction);
    }
}