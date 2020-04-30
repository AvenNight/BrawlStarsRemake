﻿using UnityEngine;

public class PlayerController : Creature
{
    //private HashSet<RangeWeapon> weapons; // была идея менять оружие выбирая из списка
    public RangeWeapon curWeapon;
    [SerializeField] private JoybuttonPlayer shotButton;

    private CreatureFinder enemyFinder;

    private void Start()
    {
        enemyFinder = new CreatureFinder(this.gameObject, enemyTags);
        curWeapon.EnemyTags = enemyTags;

        shotButton.ShootNotify += ShotButton_ShootNotify;
        shotButton.HoldShootNotify += ShotButton_HoldShootNotify;
    }

    private void ShotButton_HoldShootNotify(Vector3 direction) =>
        curWeapon.Shoot(direction != Vector3.zero ? direction : ShotDirection);

    private void ShotButton_ShootNotify() =>
        curWeapon.Shoot(ShotDirection);

    private Vector3 ShotDirection =>
        enemyFinder.Objects.Count == 0 ? shotButton.Direction : enemyFinder.Direction;

    private void FixedUpdate()
    {
        if (enemyFinder.Objects.Count != 0)
            Debug.DrawRay(this.transform.position, enemyFinder.Direction, new Color(0, 0, 1, 0.3f));
    }
}