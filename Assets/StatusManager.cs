using UnityEngine;
using System.Collections;

public class StatusManager : MonoBehaviour {
    public GameObject player;
	// Use this for initialization
    float[] modifiers = new float[8];

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float deltaTime = Time.deltaTime;
        for (int i = 0; i < modifiers.Length; ++i )
        {
            if (modifiers[i] > 0)
            {
                modifiers[i] -= deltaTime;
                if(modifiers[i] <= 0)
                {
                    switch(i)
                    {
                        case 0:
                            RemoveSpeedModifier();
                            break;
                        case 1:
                            RemoveInvulnerability();
                            break;
                        default:
                            Debug.Log("unrecognized powerup");
                            break;
                    }
                }
            }
        }
	}
    //position 0  of modifiers
    public void SpeedModifier(int mod, float time)
    {
        modifiers[0] = time;
        player.GetComponent<TouchManager>().speedModifier = mod;
    }
    void RemoveSpeedModifier()
    {
        player.GetComponent<TouchManager>().speedModifier = 1;
    }
    //position 0 of modifiers
    public void Invulnerability(float time)
    {
        //TODO
    }
    void RemoveInvulnerability()
    {
        //TODO
    }
}
