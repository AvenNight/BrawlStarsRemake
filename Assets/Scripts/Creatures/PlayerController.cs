using UnityEngine;

public class PlayerController : Creature
{
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private GameObject exit;
    [SerializeField]
    private RangeWeapon rifle;
    [SerializeField]
    private Buckshot shot;
    [SerializeField]
    private float firingRange;

    [SerializeField]
    private JoybuttonPlayer shotButton;

    private CreatureFinder enemyFinder;

    private Transform t;

    private void Start()
    {
        t = this.transform;

        rifle.DelaySec = attackSpeed;
        rifle.AttackPower = attack;
        rifle.Bullet = bullet;

        enemyFinder = new CreatureFinder(this.gameObject, "Enemy");

        shotButton.ShootNotify += ShotButton_ShootNotify;
        shotButton.HoldShootNotify += ShotButton_HoldShootNotify;
    }

    private void ShotButton_HoldShootNotify(Vector3 direction)
    {
        //rifle.Direction = direction;
        //rifle.autoAttack = true;
        shot.Shoot(direction);
    }

    private void ShotButton_ShootNotify()
    {
        //rifle.autoAttack = false;
        shot.Shoot(shotButton.Direction);
    }

    private void FixedUpdate()
    {
        SelectorAI();
    }

    private void SelectorAI()
    {
        if (enemyFinder.Objects.Count == 0)
            return;
        var direction = enemyFinder.Direction;
        //ShootingAI(direction);
    }
    private void ShootingAI(Vector3 direction)
    {
        var ray = new Ray(this.transform.position, direction);
        bool hitted = Physics.Raycast(ray, out RaycastHit hit, firingRange);
        if (hitted && hit.collider.tag == "Enemy")
        {
            rifle.Direction = direction;
            rifle.autoAttack = true;
            Debug.DrawRay(this.transform.position, direction, new Color(0, 1, 0, 0.1f));
        }
        else
        {
            rifle.autoAttack = false;
            Debug.DrawRay(this.transform.position, direction, new Color(1, 0, 0, 0.3f));
        }
    }
}