using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawn : MonoBehaviour
{
    public GameManager gameManager;
	public GameObject meteorPrefab;
    public GameObject meteorHugePrefab;

	public float maxSpawnDelay = 1.5f;
    public float minSpawnDelay = 1f;
	public float spawnXLimit;
    // Start is called before the first frame update
    void Start()
    {
        spawnXLimit = gameManager.cameraWidth / 2f - 55f;
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /////////////////////////////////////////////////////
    void Spawn()
    {
        float random = Random.Range(-spawnXLimit, spawnXLimit);
        Vector3 spawnPos = transform.position + new Vector3(random, 0f, 0f);
        Instantiate((Random.Range(0f, 1f)<0.85f)?meteorPrefab:meteorHugePrefab, spawnPos, Quaternion.identity);

        Invoke("Spawn", Random.Range(minSpawnDelay, maxSpawnDelay));
    }
}
