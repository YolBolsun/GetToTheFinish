using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public float maxDistance;
    public float cameraSpeed;
    public TouchManager touchManager;
    public PuzzleManager puzzleManager;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 location;// = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (touchManager.tracking)
        {
            location = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        else{
            location = touchManager.transform.position;
        }
        if (location != null && (location - transform.position).magnitude > maxDistance)
        {
            location.z = 0;
            //Sets camera bounds
            if (location.x > puzzleManager.width / 2)
                location.x = puzzleManager.width / 2;
            if (location.x < puzzleManager.width / -2)
                location.x = puzzleManager.width / -2;
            if (location.y > puzzleManager.height / 2)
                location.y = puzzleManager.height / 2;
            if (location.y < puzzleManager.height / -2)
                location.y = puzzleManager.height / -2;
            //ends camera bounds setting
            location.z = transform.position.z;
            if ((location - transform.position).magnitude > .2)
            {  
                transform.Translate((location - transform.position).normalized * cameraSpeed * Time.deltaTime);
            }
        }

	}
}
