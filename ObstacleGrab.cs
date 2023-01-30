using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGrab : MonoBehaviour
    
{
    private GameObject player;
    // Start is called before the first frame update
    private Vector3 offset = new Vector3(0, 2, 0);
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset;
    }
}
