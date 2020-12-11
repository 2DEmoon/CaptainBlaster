using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public Text scoreText;
	public Text gameOverText;
    public Text restartText;
    public Text playerHPText;
    ///////////////////////For Android//////////////////////////////////////////
    public GameObject mainCamera;
    static float screenRate = (float)Screen.width / (float)Screen.height;
    public float cameraWidth = 720f;
    public float cameraHeight = 1280f;
    ///////////////////////////////////////////////////////////////////////////////
    public int playerHP = 5;

    Camera cameraCom;
	int playerScore = 0;
    // Start is called before the first frame update
    void Awake()
    {
        CameraFit(screenRate);
    }

    void Start()
    {
        printHP();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    ////////////////////////////////////////////////////////
    public void AddScore(int _amount)
    {
    	playerScore += _amount;
        scoreText.text = playerScore.ToString();
        if (playerScore % 100 == 0 && playerHP<6)
        {
            AddPlayerHP();
        }
    }

    public void AddPlayerHP()
    {
        ++playerHP;
        printHP();
    }

    public void DecreasePlayerHP(int _amount)
    {
        playerHP -= _amount;
        printHP();
        if (playerHP < 1)
            PlayerDied();
    }

    public void printHP()
    {
        playerHPText.text = playerHP.ToString();
    }

    public void PlayerDied()
    {
        playerHPText.enabled = false;
    	gameOverText.enabled = true;
        restartText.enabled = true;
    	Time.timeScale = 0f;
    }

    public void Restart()
    {
        SceneManager.LoadScene("Main");
        Time.timeScale = 1f;
    }
    ////////////////////////////////////////////////////////
    void CameraFit(float screenRate)
    {
        //Debug.Log("==========================screenRate:" + screenRate);
        cameraCom = mainCamera.GetComponent<Camera>();
        if (screenRate > 800f / 1280f)
        {
            //Debug.Log("===========================test");
            cameraCom.orthographicSize = 400f / screenRate;
            Vector3 cameraPos = (cameraCom.transform).position;
            cameraPos.y = - (640f - cameraCom.orthographicSize);
            cameraCom.transform.position = cameraPos;
        }
        cameraWidth = 2 * screenRate * cameraCom.orthographicSize;
        cameraHeight = 2 * cameraCom.orthographicSize;
        //Debug.Log("===========================cameraSize:" + cameraCom.orthographicSize);
        //Debug.Log("===========================cameraWidth:" + cameraWidth);
        //Debug.Log("===========================cameraHeight:" + cameraHeight);
    }
}
