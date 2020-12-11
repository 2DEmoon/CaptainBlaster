using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour
{
	public float speed = -100f;
	public float lowerYValue = -1000f;
	public float upperYValue = 1000f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0f, speed * Time.deltaTime, 0f);
        if (transform.position.y <= lowerYValue)
            transform.position = new Vector3(0f, upperYValue, 0f);
    }
}
