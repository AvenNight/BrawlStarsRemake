using System;
using UnityEngine;

public class JoybuttonPlayer : MonoBehaviour
{
    private DynamicJoybutton joybutton;
    public Vector3 Direction => Vector3.forward * joybutton.Vertical + Vector3.right * joybutton.Horizontal;

    public float Distance = 10f;
    public DrawCone DrawCone;

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
            HoldShootNotify?.Invoke(Direction);
        else
            ShootNotify?.Invoke();
    }

    public void FixedUpdate()
    {
        if (joybutton.Direction == Vector2.zero)
        {
            DrawCone.Enable = false;
            return;
        }
        DrawCone.Color = joybutton.Holded ? new Color(0, 0, 1, 0.33f) : new Color(1, 0, 0, 0.33f);
        DrawCone.Enable = true;
        transform.forward = Direction;
    }

    private void OnDestroy() => joybutton.PressNotify -= Joybutton_PressNotify;
}