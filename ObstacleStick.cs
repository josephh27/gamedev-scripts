using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ObstacleStick : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rb;
    private SpawnManager spawnManager;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(6.0f * 10.0f * Time.deltaTime, 0, 0);
        //transform.Rotate(0, 90, 0);
    }

    private void OnTriggerEnter(Collider other)
    
    {
       rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;

    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Shape1Bench") && gameObject.CompareTag("Shape 1"))
        {
            spawnManager.UpdateScore(4);
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Shape2Bench") && gameObject.CompareTag("Shape 2"))
        {
            spawnManager.UpdateScore(6);
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Shape3Bench") && gameObject.CompareTag("Shape 3"))
        {
            spawnManager.UpdateScore(8);
            Destroy(gameObject);
        }
    }
    
}
