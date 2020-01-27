using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    public Map map;
    private int actualNode = 0;
    private bool inObjective = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inObjective == false)
        {
            Vector3 objectiveNoce = new Vector3(map.route[actualNode].X + 0.5f, 0.5f, map.route[actualNode].Y + 0.5f);

            if (Vector3.Magnitude(transform.position - objectiveNoce) < Mathf.Epsilon)
            {
                actualNode++;
                if (actualNode == map.route.Count)
                {
                    inObjective = true;
                }
            }

            //  look at objective.

            transform.LookAt(objectiveNoce);
            transform.Translate(Vector3.forward * Time.deltaTime);
        }
    }
}
