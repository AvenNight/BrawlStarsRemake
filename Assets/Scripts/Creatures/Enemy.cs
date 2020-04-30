using UnityEngine;
using UnityEngine.AI;

public class Enemy : Creature
{
    public float UpdateTimeAttack;
    public float UpdateTimeMove;
    public float AggroDistance;
    public float AttackRange;
    public float WanderRadius;

    [SerializeField] private RangeWeapon curWeapon;

    private ObjectsFinder playersFinder;
    private Vector3 direction;

    void Start()
    {
        curWeapon.EnemyTags = enemyTags;
        InvokeRepeating("MovenentAI", 0f, UpdateTimeMove);
        InvokeRepeating("AttackAI", 0f, UpdateTimeAttack);
    }

    private void MovenentAI()
    {
        if (!TryGetDirection(out direction)) return;
        if (playersFinder.DistanceToNearest < AggroDistance)
            agent.SetDestination(playersFinder.NearestObject.transform.position);
        else
        {
            var newDestination = RandomNavSphere(this.transform.position, WanderRadius, -1);
            agent.SetDestination(newDestination);
        }
    }

    private bool TryGetDirection(out Vector3 direction)
    {
        playersFinder = new CreatureFinder(this.gameObject, enemyTags);
        bool result = playersFinder.Objects.Count != 0;
        direction = result ? playersFinder.Direction : Vector3.zero;
        return result;
    }

    private Vector3 RandomNavSphere(Vector3 origin, float wanderRadius, int layermask)
    {
        Vector3 randDirection = UnityEngine.Random.insideUnitSphere * wanderRadius;
        NavMesh.SamplePosition(randDirection + origin, out NavMeshHit navHit, wanderRadius, layermask);
        return navHit.position;
    }

    private void AttackAI()
    {
        if (!TryGetDirection(out direction)) return;
        var ray = new Ray(this.transform.position, direction);
        bool hitted = Physics.Raycast(ray, out RaycastHit hit, AttackRange);
        if (hitted && (hit.collider.tag == "Player"))
            curWeapon.Shoot(direction);
    }
}