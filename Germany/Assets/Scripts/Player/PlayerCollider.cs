using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    [SerializeField] MovementWatcher movementWatcher;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "EndLevel")
        {
            gameObject.SetActive(false);
            GameManager.Instance.CanvasManager.EndGameMenu.SetActive(true);
            GameManager.Instance.CanvasManager.UpPanel.SetActive(false);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        // StopCoroutine(ResetGameCountdown());
        // StartCoroutine(ResetGameCountdown());

        var tag = other.gameObject.tag;

        if(tag == "Wall" || tag == "Bumper" || tag == "SpeedPad")
        {
            movementWatcher.ResetCountdown();
        }
    }
}
