using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCar : MonoBehaviour
{
    public float carSpeed;
    private int boundary = 40;
    private SpawnManager carPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * carSpeed * Time.deltaTime);

        if ((transform.position.x < -boundary) || (transform.position.x > boundary))
        {
            Destroy(gameObject);
        }
    }
}
