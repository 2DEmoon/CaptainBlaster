using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorMover : MonoBehaviour
{
    public GameManager gameManager;
	public float xspeed;
    public float yspeed;

    //bool dealingDamage = true;
	Rigidbody2D tmpRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        xspeed = gameManager.cameraWidth / 20f;
        yspeed = gameManager.cameraHeight / 10f;
        tmpRigidbody = GetComponent<Rigidbody2D>();
        tmpRigidbody.velocity = new Vector2(Random.Range(-2f * xspeed, 2f * xspeed), - Random.Range(0.5f * yspeed, 2.5f * yspeed));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Fire")
        {
            Destroy(gameObject);
            gameManager.AddScore(1);
        }

    }
    // void OnTriggerEnter(Collider other)
    // {
    //     if (other.tag == "DamageImmunityArea")
    //         Debug.Log("DamageImmunityArea");
    // }
}
