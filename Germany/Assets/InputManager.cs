using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


[DefaultExecutionOrder(-1)]
public class InputManager : MonoBehaviour
{
    public delegate void StartTouchEvent(Vector2 pos, float time);
    public event StartTouchEvent OnStartTouch;
    public delegate void EndTouchEvent(Vector2 pos, float time);
    public event EndTouchEvent OnEndTouch;
    




    private InputActions inputActions;

    private void Awake() {
        inputActions = new InputActions();
    }

    private void OnEnable() {
        inputActions.Enable();
    }

    private void OnDisable() {
        inputActions.Disable();
    }

    private void Start() {
        inputActions.Map.TouchPress.started += ctx => StartTouch(ctx);
        inputActions.Map.TouchPress.canceled += ctx => EndTouch(ctx);
    }

    private void StartTouch(InputAction.CallbackContext context)
    {
        Debug.Log("Touch started " + context.ReadValue<float>() + " " + inputActions.Map.TouchPosition.ReadValue<Vector2>());
        if(OnStartTouch != null) OnStartTouch(inputActions.Map.TouchPosition.ReadValue<Vector2>(), (float)context.startTime);
    }

    private void EndTouch(InputAction.CallbackContext context)
    {
        Debug.Log("Touch ended " + context.ReadValue<float>() + " " + inputActions.Map.TouchPosition.ReadValue<Vector2>());
        if(OnEndTouch != null) OnEndTouch(inputActions.Map.TouchPosition.ReadValue<Vector2>(), (float)context.time);
    }
}
