using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigidbody2D;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "EndLevel")
        {
            rigidbody2D.velocity = Vector3.zero;
            gameObject.SetActive(false);
            GameManager.Instance.CanvasManager.EndGameMenu.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        
    } 
}
