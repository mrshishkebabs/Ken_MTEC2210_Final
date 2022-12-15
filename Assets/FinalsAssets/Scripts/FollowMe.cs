using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMe : MonoBehaviour
{
    public GameObject player;
    void Start()
    {

    }

    void Update()
    {
        if (player != null)
        { 
            transform.position = new Vector3(transform.position.x, player.transform.position.y + 2, transform.position.z);
        }
    }
}
