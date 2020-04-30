using UnityEngine;

public class DrawCone : MonoBehaviour
{
    [HideInInspector]
    public float Angle;
    [HideInInspector]
    public float Distance;
    [HideInInspector]
    public bool Enable;
    [HideInInspector]
    public Color Color;

    private Transform tf;

    private void Start() => tf = this.transform;

    private void OnDrawGizmos()
    {
        if (!Enable) return;
        Quaternion upRayRotation = Quaternion.AngleAxis(-Angle / 2, Vector3.up);
        Quaternion downRayRotation = Quaternion.AngleAxis(Angle / 2, Vector3.up);

        Vector3 upRayDirection = upRayRotation * tf.forward * Distance;
        Vector3 downRayDirection = downRayRotation * tf.forward * Distance;

        Gizmos.color = Color;
        Gizmos.DrawRay(tf.position, upRayDirection);
        Gizmos.DrawRay(tf.position, downRayDirection);
        Gizmos.DrawLine(tf.position + downRayDirection, tf.position + upRayDirection);
    }
}