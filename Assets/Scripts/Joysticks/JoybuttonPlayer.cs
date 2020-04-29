using System;
using UnityEngine;

public class JoybuttonPlayer : MonoBehaviour
{
    private DynamicJoybutton joybutton;
    public Vector3 Direction => Vector3.forward * joybutton.Vertical + Vector3.right * joybutton.Horizontal;

    public float Distance = 10f;

    public event Action<Vector3> HoldShootNotify;
    public event Action ShootNotify;

    private void Start()
    {
        joybutton = FindObjectOfType<DynamicJoybutton>();
        joybutton.PressNotify += Joybutton_PressNotify;
    }

    private void Joybutton_PressNotify()
    {
        if (joybutton.Holded)
        {
            HoldShootNotify?.Invoke(Direction);
            Debug.Log(" Direct SHOOT !");
        }
        else
        {
            ShootNotify?.Invoke();
            Debug.Log(" SHOOT !");
        }
    }

    public void FixedUpdate()
    {
        if (joybutton.Direction == Vector2.zero) return;
        Debug.DrawLine(this.transform.position, this.transform.position + Direction.normalized * Distance, joybutton.Holded ? Color.blue : Color.red);
        GL.Begin(GL.LINES);
        LineRenderer lineRenderer = new LineRenderer();
        transform.forward = Direction;
    }
}