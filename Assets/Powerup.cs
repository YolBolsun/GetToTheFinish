using UnityEngine;
using System.Collections;

public class Powerup : MonoBehaviour {

    public StatusManager statusManager;

    public int speedModifier;
    public float speedModifierTime;

    public float invulnerabilityTime;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
            Debug.Log("Doing Powerups");
            statusManager.SpeedModifier(speedModifier, speedModifierTime);
            statusManager.Invulnerability(invulnerabilityTime);
            Destroy(this.gameObject);
        }
    }
}
