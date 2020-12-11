using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageImmunityAreaLeftFit : MonoBehaviour
{
	public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3( - gameManager.cameraWidth / 2f - 50f, -200f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
