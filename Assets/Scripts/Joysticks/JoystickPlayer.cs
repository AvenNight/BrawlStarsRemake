using System;
using UnityEngine;

public class JoystickPlayer : MonoBehaviour
{
    private Joystick joystick;

    [SerializeField]
    private float speed;
    [SerializeField]
    private Rigidbody rb;

    private void Start()
    {
        joystick = FindObjectOfType<DynamicJoystick>();
    }

    public void FixedUpdate()
    {
        var direction = Vector3.forward * joystick.Vertical + Vector3.right * joystick.Horizontal
            + new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        rb.velocity = direction * speed;

        if (direction == Vector3.zero) return;
        transform.forward = direction;
    }
}