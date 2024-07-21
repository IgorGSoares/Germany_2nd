using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class TriggerCameraMove : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] CinemachineVirtualCamera vCam;

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player") 
        {
            vCam.Follow = player.transform;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            vCam.Follow = null;
        }
    }
}
