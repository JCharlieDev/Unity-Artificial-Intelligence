using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineVisionFollow : MonoBehaviour
{
    public Transform objToWatch;

    public float velocity = 7.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //  We rotate our gameObject to rotate to our object to watch.
        //  We would modify this script if we're not working on a plane.
        transform.LookAt(objToWatch);

        transform.Translate(Vector3.forward * velocity * Time.deltaTime);
    }
}
