using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float offsetFromMidpoint = 0; //move the camera if position y + this is crossed

    void Update()
    {
        if(player.transform.position.y> transform.position.y+offsetFromMidpoint)
        {
            transform.position = new Vector3(transform.position.x, player.transform.position.y-offsetFromMidpoint, transform.position.z);
        }
    }
}
