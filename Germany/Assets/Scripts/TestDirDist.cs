using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDirDist : MonoBehaviour
{
    [SerializeField] Transform PointA;
    [SerializeField] Transform PointB;

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
}
