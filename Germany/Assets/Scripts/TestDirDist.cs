using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestDirDist : MonoBehaviour
{
    [SerializeField] Transform PointA;
    [SerializeField] Transform PointB;
    [SerializeField] Transform PointC;

    Vector2 initialPos;
    Vector2 finalPos;

    [ContextMenu("CalculateDirection")]
    public void CalculateDirection()
    {
        var dir = (PointA.position - PointB.position).normalized;
        Debug.Log(dir);
        Debug.DrawLine(PointA.position, PointB.position, Color.yellow, /*Mathf.Infinity*/ 5f);
    }

    [ContextMenu("CalculateDistance")]
    public void CalculateDistance()
    {
        var result = Vector2.Distance(PointA.position, PointB.position);
        Debug.Log(result * 100);
    }

    public void SetInitialPos(InputAction.CallbackContext context)
    {
        var value = context.ReadValue<Vector2>();
        PointC.gameObject.SetActive(context.action.IsPressed());
        PointC.position = value;
        Debug.Log(value);
    }
}
