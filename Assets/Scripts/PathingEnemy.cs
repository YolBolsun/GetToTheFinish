using UnityEngine;
using System.Collections;

public class PathingEnemy : MonoBehaviour {

    public Vector3 begin;
    public Vector3 end;
    public float movementSpeed;

    bool toEnd = true;
    float distanceToTravel;

	// Use this for initialization
	void Start () {
        distanceToTravel = (end - begin).magnitude;
	}
	
	// Update is called once per frame
	void Update () {
	    if(toEnd)
        {
            transform.Translate((end - begin).normalized * movementSpeed * Time.deltaTime);
            if((transform.position-begin).magnitude > distanceToTravel)
            {
                toEnd = false;
            }
        }
        else
        {
            transform.Translate((begin - end).normalized * movementSpeed * Time.deltaTime);
            if ((transform.position - end).magnitude > distanceToTravel)
            {
                toEnd = true;
            }
        }
	}
}
