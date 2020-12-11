using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorHugeMover : MonoBehaviour
{
    public GameManager gameManager;
	public float xspeed;
    public float yspeed;

    //bool dealingDamage = true;
    int MeterorHugeHP = 5;
    int splitNum = 3;
	Rigidbody2D tmpRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        xspeed = gameManager.cameraWidth / 20f;
        yspeed = gameManager.cameraHeight / 10f;
        tmpRigidbody = GetComponent<Rigidbody2D>();
        tmpRigidbody.velocity = new Vector2(Random.Range(-0.3f * xspeed, 0.3f * xspeed), - Random.Range(0.1f * yspeed, 0.3f * yspeed));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Fire")
        {
            --MeterorHugeHP;
            if (MeterorHugeHP == 0)
            {
                SpawnWhenDestroyed();
                Destroy(gameObject);
                gameManager.AddScore(5);
            }
        }

    }

    void SpawnWhenDestroyed()
    {
        for (int i = 0;i < splitNum; i++)
        {
            GameObject tmpMeteor = Instantiate(Resources.Load<GameObject>("Meteor"), transform.position, Quaternion.identity);
        }
    }
    // void OnTriggerEnter(Collider other)
    // {
    //     if (other.tag == "DamageImmunityArea")
    //         Debug.Log("DamageImmunityArea");
    // }
}
