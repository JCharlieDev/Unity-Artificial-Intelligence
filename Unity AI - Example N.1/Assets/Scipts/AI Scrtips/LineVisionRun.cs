using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineVisionRun : MonoBehaviour
{
    public Transform objToRunFrom;

    public float velocity = 7.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 point = objToRunFrom.position - transform.position;
        Vector3 vision = transform.position - point;

        vision.y = objToRunFrom.position.y;

        transform.LookAt(vision);

        transform.Translate(Vector3.forward * velocity * Time.deltaTime);
    }
}
