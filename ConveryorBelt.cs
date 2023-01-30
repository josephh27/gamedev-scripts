using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveryorBelt : MonoBehaviour
{
    public float speed;
    Rigidbody rbody;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 pos = rbody.position;
        rbody.position += Vector3.forward * speed * Time.fixedDeltaTime;
        rbody.MovePosition(pos);
    }
}
