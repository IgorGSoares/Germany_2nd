using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObjectEffects : MonoBehaviour
{
    [SerializeField] protected Rigidbody2D player;
    [SerializeField] protected Collider collider;

    public virtual void ActiveEffect()
    {
        Debug.Log("Use effect");
    }
}
