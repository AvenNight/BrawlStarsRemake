using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class DynamicJoybutton : DynamicJoystick
{
    [HideInInspector]
    public bool Pressed;
    [HideInInspector]
    public bool Holded;
    [SerializeField]
    private float holdTimeSec = 2f;

    public event Action PressNotify;

    public override void OnPointerDown(PointerEventData eventData)
    {
        Pressed = true;
        StartCoroutine("HooldingTime");
        base.OnPointerDown(eventData);
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        PressNotify?.Invoke();
        Pressed = false;
        Holded = false;
        StopCoroutine("HooldingTime");
        base.OnPointerUp(eventData);
    }

    private IEnumerator HooldingTime()
    {
        yield return new WaitForSeconds(holdTimeSec);
        Holded = Pressed;
    }
}
