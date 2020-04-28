using UnityEngine;

public class JoystickPlayer : MonoBehaviour
{
    private Joystick joystick;
    private DynamicJoybutton joybutton;

    public float speed;
    public Rigidbody rb;

    public float distance = 10f;

    private void Start()
    {
        joystick = FindObjectOfType<DynamicJoystick>();
        joybutton = FindObjectOfType<DynamicJoybutton>();
        joybutton.PressNotify += Joybutton_PressNotify;
    }

    private void Joybutton_PressNotify()
    {
        if (joybutton.Holded)
            Debug.Log(" Direct SHOOT !");
        else
            Debug.Log(" SHOOT !");
    }

    public void FixedUpdate()
    {
        JoystickUpdate();
        JoybuttonUpdate();
    }

    private void JoystickUpdate()
    {
        var direction = Vector3.forward * joystick.Vertical + Vector3.right * joystick.Horizontal;
        rb.velocity = direction * speed;

        if (direction == Vector3.zero) return;
        transform.forward = direction;
    }

    private void JoybuttonUpdate()
    {
        if (joybutton.Direction == Vector2.zero) return;
        var direction = Vector3.forward * joybutton.Vertical + Vector3.right * joybutton.Horizontal;
        Debug.DrawLine(this.transform.position, this.transform.position + direction.normalized * distance, joybutton.Holded ? Color.blue : Color.red);
        transform.forward = direction;
    }
}