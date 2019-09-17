using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathParticle : MonoBehaviour {

    public float timeLived = 2;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timeLived -= Time.deltaTime;
        if(timeLived <= 0)
        {
            Destroy(gameObject);
        }
	}
}
