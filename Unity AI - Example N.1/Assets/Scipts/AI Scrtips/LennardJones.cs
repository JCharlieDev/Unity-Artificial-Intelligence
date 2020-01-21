using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LennardJones : MonoBehaviour
{
    public Transform player;

    


    private void Start()
    {

    }

    void Update()
    {
        //  Leonnard Jones potential function.
        Vector3 r = player.position - transform.position;

        float A = 700.0f;
        float B = 250.0f;
        float n = 3.0f;
        float m = 2.0f;
        float d = r.magnitude / 5;
        float U = -A / Mathf.Pow(d, n) + B / Mathf.Pow(d, m);

        if (U < -10)
        {
            U = -10;
        }
        if (U > 10)
        {
            U = 10;
        }

        transform.LookAt(player);

        //  Move towards the player.

        transform.Translate(Vector3.forward * U * Time.deltaTime);

        Debug.Log(U);

    }
}
