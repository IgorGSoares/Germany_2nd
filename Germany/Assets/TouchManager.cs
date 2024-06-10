using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TouchManager : MonoBehaviour
{
    [SerializeField] GameObject handler;
    [SerializeField] PlayerInput playerInput;

    private InputAction touchPosAction;
    private InputAction touchPressAction;
    private InputAction touchDragAction;

    private void Awake() {
        touchPosAction = playerInput.actions["Tap"];
        touchPressAction = playerInput.actions["Press"];
        touchDragAction = playerInput.actions["Drag"];
    }

    private void OnEnable() {
        touchPressAction.performed += TouchPressed;
    }

    private void OnDisable() {
        touchPressAction.performed -= TouchPressed;
    }

    private void TouchPressed(InputAction.CallbackContext context)
    {
        Vector2 pos = touchPosAction.ReadValue<Vector2>();
        pos = Camera.main.ScreenToWorldPoint(pos);
        handler.SetActive(true);
        handler.transform.position = pos;
    }

    // private void Update() {
    //     if(touchPressAction.WasPerformedThisFrame()) //NOTE: wasreleasedthisframe
    //     {
    //         Vector2 pos = touchPressAction.ReadValue<Vector2>();
    //         Debug.Log(pos);
    //         pos = Camera.main.ScreenToWorldPoint(pos);
    //         handler.SetActive(true);
    //         handler.transform.position = pos;
    //     }
    // }
}
