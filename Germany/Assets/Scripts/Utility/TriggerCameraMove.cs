using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCameraMove : MonoBehaviour
{
    [SerializeField] GameObject player;
    [HideInInspector] public float speed;
    bool follow = false;

    Rigidbody2D playerRB;

    void Start()
    {
        playerRB = player.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        var pos = Camera.main.transform.position;
        if (follow)
        {
            Debug.Log("is following");
            //Camera.main.transform.position = pos + player.transform.up * playerRB.velocity.y * Time.deltaTime;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player") follow = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player") follow = false;
    }
}
