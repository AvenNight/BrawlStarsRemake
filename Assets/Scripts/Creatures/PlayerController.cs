using UnityEngine;

public class PlayerController : Creature
{
    [SerializeField]
    private RangeWeapon weapon;

    [SerializeField]
    private JoybuttonPlayer shotButton;

    [SerializeField]
    private BarScript bar;

    private CreatureFinder enemyFinder;

    private void Start()
    {
        enemyFinder = new CreatureFinder(this.gameObject, "Enemy");

        shotButton.ShootNotify += ShotButton_ShootNotify;
        shotButton.HoldShootNotify += ShotButton_HoldShootNotify;
    }

    private void Update()
    {
        bar.BarChange((float)Hp / MaxHp);
        //if (Input.GetKeyDown(KeyCode.Q))
        //{
        //    bar.BarChange(0.5f);
        //}
    }

    private void ShotButton_HoldShootNotify(Vector3 direction) =>
        weapon.Shoot(direction);

    private void ShotButton_ShootNotify() =>
        weapon.Shoot(enemyFinder.Objects.Count == 0 ? shotButton.Direction : enemyFinder.Direction);

    private void FixedUpdate()
    {
        if (enemyFinder.Objects.Count != 0)
            Debug.DrawRay(this.transform.position, enemyFinder.Direction, new Color(0, 0, 1, 0.3f));
    }
}