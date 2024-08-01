using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementWatcher : MonoBehaviour
{
    [SerializeField] float countdown;
    [SerializeField] Rigidbody2D rigidbody2D;

    bool isMoving = false;

    void OnEnable()
    {
        GlobalActions.onGameBegins += StartCountDown;
    }

    void OnDisable()
    {
        GlobalActions.onGameBegins -= StartCountDown;
    }

    void FixedUpdate()
    {
        if(isMoving && rigidbody2D.velocity.magnitude < 0.5)
        {
            StopCountdown();
            rigidbody2D.velocity = Vector3.zero;
            gameObject.SetActive(false);
            GameManager.Instance.EndGame();
        }
    }

    void StartCountDown()
    {
        if (!isMoving) isMoving = true;

        StartCoroutine(ResetGameCountdown());
    }

    void StopCountdown()
    {
        StopCoroutine(ResetGameCountdown());
    }

    public void ResetCountdown()
    {
        StopCountdown();
        StartCountDown();
    }

    IEnumerator ResetGameCountdown()
    {
        yield return new WaitForSeconds(countdown);

        //rigidbody2D.velocity = Vector3.zero;
        gameObject.SetActive(false);
        GameManager.Instance.EndGame();
    }
}
