using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    TouchManager touchManager;

	// Use this for initialization
	void Start () {
        touchManager = GetComponent<TouchManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        Debug.Log("Hit something");
        if(coll.CompareTag("Enemy"))
        {
            Debug.Log("Hit an Enemy");
        }
    }
}
