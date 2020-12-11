using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShipControl : MonoBehaviour
{
	public GameManager gameManager;
	public GameObject bulletPrefab;

	public float speed;
	public float xLimit;
	public float reloadTime = 0.25f;

	////////////////////////For Android///////////////////////////
	public float xAcc;
	public float xDec;

	int direction = 0;
	bool ActFire = false;
	float curSpeed = 0f;
	float curAbsSpeed = 0f;
	/////////////////////////////////////////////////////////////

	float elapsedTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        speed = gameManager.cameraWidth;
        xLimit = gameManager.cameraWidth / 2f - 55f;

        ///////////////////////For Android//////////////////////
        xAcc = 2 * gameManager.cameraWidth;
        xDec = gameManager.cameraWidth;
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;

        float xInput = Input.GetAxis("Horizontal");
        //////////////////For Android//////////////////////////
        curSpeed += direction * xAcc * Time.deltaTime;
        curSpeed = Mathf.Clamp(curSpeed, -speed, speed);
        if (direction == 0 && Mathf.Abs(curSpeed) > 1e-10 )
        {
        	curAbsSpeed = Mathf.Abs(curSpeed);
        	curAbsSpeed -= xDec * Time.deltaTime;
        	curAbsSpeed = Mathf.Clamp(curAbsSpeed, 0f, speed);
        	curSpeed = curSpeed / Mathf.Abs(curSpeed) * curAbsSpeed;
        }
        transform.Translate(curSpeed * Time.deltaTime, 0f, 0f);
        if (Mathf.Abs(curSpeed) < 1e-10) {
        ///////////////////////////////////////////////////////////////////
		transform.Translate(xInput * speed * Time.deltaTime, 0f, 0f);	}
        Vector3 position = transform.position;
        position.x = Mathf.Clamp(position.x, -xLimit, xLimit);
        transform.position = position;

        if ((Input.GetButtonDown("Jump") || ActFire == true) && elapsedTime > reloadTime)
        {
        	Vector3 spawnPos = transform.position;
        	spawnPos += new Vector3(0, 100f, 0);
        	Instantiate(bulletPrefab, spawnPos, Quaternion.identity);

        	elapsedTime = 0f;
        	ActFire = false;
        }
    }
    //////////////////////////////////////////////////////////////////////////////////
    void OnTriggerEnter2D(Collider2D other)
    {
    	gameManager.PlayerDied();
    }
    ///////////////////////For Android/////////////////////////////////////////
    public void OnBtnLeftDown()
    {
    	Debug.Log("==================>OnBtnLeftDown");
    	direction = -1;
    }

    public void OnBtnLeftUp()
    {
    	Debug.Log("==================>OnBtnLeftUp");
    	direction = 0;
    }

    public void OnBtnRightDown()
    {
    	Debug.Log("==================>OnBtnRightDown");
    	direction = 1;
    }

    public void OnBtnRightUp()
    {
    	Debug.Log("==================>OnBtnRightUp");
    	direction = 0;
    }

    public void OnBtnFireDown()
    {
    	Debug.Log("==================>OnBtnFireDown");
    	ActFire = true;
    }
}
