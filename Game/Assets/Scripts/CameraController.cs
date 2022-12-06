using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform goal;
    private Vector3 offset;

    void Start()
    {
        offset =  transform.position - goal.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3(transform.position.x, transform.position.y, offset.z + goal.position.z);
        transform.position = newPos;
    }
}
