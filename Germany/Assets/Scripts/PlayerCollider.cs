using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigidbody2D;

    void OnEnable()
    {
        GlobalActions.onGameBegins += StartCountDown;
    }

    void OnDisable()
    {
        GlobalActions.onGameBegins -= StartCountDown;
    }

    void StartCountDown()
    {
        StartCoroutine(ResetGameCountdown());
    }

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

    void OnCollisionEnter(Collision other)
    {
        StopCoroutine(ResetGameCountdown());
        StartCoroutine(ResetGameCountdown());
    }

    IEnumerator ResetGameCountdown()
    {
        yield return new WaitForSeconds(10);

        rigidbody2D.velocity = Vector3.zero;
        gameObject.SetActive(false);
        GameManager.Instance.CanvasManager.EndGameMenu.SetActive(true);
    }
}
