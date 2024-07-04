using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InitialControl : MonoBehaviour
{
    [SerializeField] RectTransform target;

    bool isPressed = false;
    float forceValue = 0f;

    public void HoldButton(InputAction.CallbackContext context)
    {
        isPressed = context.action.IsPressed();
    }

    private void Update() {
        if(isPressed) forceValue += 25f * Time.deltaTime;
        else forceValue = 0;

        Debug.Log("force value is: " + forceValue);
    }

    public void SetRotationTarget(float v)
    {
        target.rotation = Quaternion.EulerAngles(0, 0, v);
    }
}
