using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCube : Enemy {

    GameObject player;
    public float speed = 5;
    Rigidbody rbd;
    AudioSource audioSource;
    public AudioMusic audio;
    public GameObject explosion;

	// Use this for initialization
	void Start () {
        rbd = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
        audioSource = GameObject.FindGameObjectWithTag("SoundPlayer").GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        FollowPlayer();
	}

    private void FollowPlayer()
    {
        rbd.MovePosition(Vector3.MoveTowards(transform.position, player.transform.position,speed*Time.deltaTime));
    }

    public override void Die()
    {
        audioSource.PlayOneShot(audio.soundToPlay);
        Instantiate(explosion, gameObject.transform.position,Quaternion.identity);
        Destroy(gameObject);
    }
}
