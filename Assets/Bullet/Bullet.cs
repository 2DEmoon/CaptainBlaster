using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public float speed;

	GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        speed = 2 * gameManager.cameraHeight;
        Rigidbody2D rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = new Vector2(0f, speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    ////////////////////////////////////////////////////////
    void OnCollisionEnter2D(Collision2D other)
    {
    	Destroy(gameObject);
    }
}
