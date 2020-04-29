﻿using UnityEngine;

public class PlayerController : Creature
{
    [SerializeField]
    private RangeWeapon curWeapon;

    //private HashSet<RangeWeapon> weapons; // была идея менять текущее оружие выбирая из списка

    [SerializeField]
    private JoybuttonPlayer shotButton;

    private CreatureFinder enemyFinder;

    private void Start()
    {
        enemyFinder = new CreatureFinder(this.gameObject, "Enemy");

        shotButton.ShootNotify += ShotButton_ShootNotify;
        shotButton.HoldShootNotify += ShotButton_HoldShootNotify;
    }

    private void ShotButton_HoldShootNotify(Vector3 direction) =>
        curWeapon.Shoot(direction);

    private void ShotButton_ShootNotify() =>
        curWeapon.Shoot(enemyFinder.Objects.Count == 0 ? shotButton.Direction : enemyFinder.Direction);

    private void FixedUpdate()
    {
        if (enemyFinder.Objects.Count != 0)
            Debug.DrawRay(this.transform.position, enemyFinder.Direction, new Color(0, 0, 1, 0.3f));
    }
}