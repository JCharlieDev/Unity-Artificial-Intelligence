using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotateAround : MonoBehaviour
{
    public Transform objective;
    public float velocity = 20.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(objective.position, Vector3.up, velocity * Time.deltaTime);
    }
}
