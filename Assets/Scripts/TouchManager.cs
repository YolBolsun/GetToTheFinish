using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TouchManager : MonoBehaviour {

    public bool tracking = false;
    public bool touchEnabled = true;
    List<Vector3> directions = new List<Vector3>();
    LayerMask groundLayer = 1 << 8;
    public float maxSpeed;
    public int speedModifier = 1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (touchEnabled)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                //Debug.Log("Mouse down");
                tracking = true;
                directions.Add(transform.position);
            }
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                //Debug.Log("Mouse Up");
                tracking = false;
                touchEnabled = false;
                for (int i = 0; i < directions.Count-1; ++i )
                {
                    if((directions[i+1]-directions[i]).magnitude > maxSpeed)
                    {
                        Vector3 newLoc = (directions[i+1] - directions[i]).normalized * .5f* maxSpeed + directions[i];
                        directions.Insert(i + 1, newLoc);
                    }
                }
            }
            if (tracking)
            {
               // RaycastHit hit;
                Vector3 location = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                location.z = 0;
                directions.Add(location);
                //Debug.Log(location);
               /* if (hit.collider != null)
                {
                    directions.Add(hit.transform.position);
                    Debug.Log(hit.collider.transform.position);
                }
                else
                {
                    Debug.Log("Raycast didn't hit anything");
                }*/
            }
        }
        else
        {
            for (int i = 0; i < speedModifier; ++i)
            {
                if (directions.Count > 0)
                {
                    transform.Translate(directions[0] - transform.position);
                    directions.RemoveAt(0);
                }
                else
                {
                    touchEnabled = true;
                }
            }
        }
	}
}
