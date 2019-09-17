using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCylinder : Enemy
{

    GameObject player;
    public float speed = 5;
    Rigidbody rbd;
    AudioSource audioSource;
    public AudioMusic audio;
    public GameObject explosion;
    public GameObject bulletPrefab;
    public float fireDelay = 5f;
    private float delayBeforeNextFire = 0;
    // Use this for initialization
    void Start()
    {
        rbd = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
        audioSource = GameObject.FindGameObjectWithTag("SoundPlayer").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
        ShootPlayer();
    }

    private void FollowPlayer()
    {
        rbd.MovePosition(Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime));
    }

    private void ShootPlayer()
    {
        delayBeforeNextFire -= Time.deltaTime;
        if (delayBeforeNextFire <= 0)
        {
            Vector3 relPos = player.transform.position - transform.position;
            relPos.y = transform.position.y;
            rbd.MoveRotation(Quaternion.FromToRotation(transform.forward, relPos));
            ShootBullet();
            delayBeforeNextFire = fireDelay;
        }

    }

    private void ShootBullet()
    {
        Instantiate(bulletPrefab, transform.position + (transform.forward * 2), transform.rotation);
    }

    public override void Die()
    {
        audioSource.PlayOneShot(audio.soundToPlay);
        Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
