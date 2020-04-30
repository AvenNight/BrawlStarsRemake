using UnityEngine;

public abstract class RangeWeapon : MonoBehaviour
{

    [SerializeField]
    protected float distance;
    public float Distance => distance;
    [SerializeField]
    protected float angle;
    public float Angle => angle;

    public abstract void Shoot(Vector3 direction);
}