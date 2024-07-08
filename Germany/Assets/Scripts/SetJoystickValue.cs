using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetJoystickValue : MonoBehaviour
{
    [SerializeField] FixedJoystick fixedJoystick;
    [SerializeField] GameControls control;
    [SerializeField] float multiplyer;

    private void OnEnable() {
        control.SetRotationTarget(0);
    }

    private void Update()
    {
        if (fixedJoystick == null || fixedJoystick.Horizontal == 0) return;

        var v = fixedJoystick.Horizontal * multiplyer;

        control.SetRotationTarget(v);
    }
}
