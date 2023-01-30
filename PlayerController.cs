using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    
    public float movementSpeed;
    public float verticalInput;
    public float horizontalInput;
    private float slowDuration = 2.0f;
    private bool isGrabbing = false;
    private bool hasGrabbed = false;
    private GameObject previousGrabbed;


    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * movementSpeed);
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * movementSpeed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isGrabbing = true;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (hasGrabbed)
            {
                DropObject(previousGrabbed);
            }
            isGrabbing = false;
        }
        Debug.Log("okay");


    }
    private void OnCollisionEnter(Collision other)
    {
     
        if (other.gameObject.CompareTag("Enemy"))
        {
            movementSpeed -= 3;
            if (hasGrabbed)
            {
                DropObject(previousGrabbed);
            }
            StartCoroutine(SlowdownCooldown());
        }

        if ((other.gameObject.CompareTag("Shape 1") || other.gameObject.CompareTag("Shape 2")
            || other.gameObject.CompareTag("Shape 3")) && isGrabbing && !hasGrabbed)
        {
            other.gameObject.GetComponent<ObstacleGrab>().enabled = true;
            hasGrabbed = true;
            previousGrabbed = other.gameObject;
            Debug.Log("okay");
        }
    }
    IEnumerator SlowdownCooldown()
    {
        yield return new WaitForSeconds(slowDuration);
        movementSpeed += 3;
    }

    private void DropObject(GameObject obj)
    {
        obj.transform.position = transform.position + new Vector3(0, 1.5f, 0);
        obj.gameObject.GetComponent<ObstacleGrab>().enabled = false;
        hasGrabbed = false;
    }
}
