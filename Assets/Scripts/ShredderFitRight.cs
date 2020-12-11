using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShredderFitRight : MonoBehaviour
{
	///////////////////References////////////////////
	public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(gameManager.cameraWidth / 2f + 125f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
