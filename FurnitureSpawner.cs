using UnityEngine;
using System.Collections;

public class FurnitureSpawner : MonoBehaviour {

    public GameObject chairPrefab;
    public static GameObject newChair;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 randomSpawnPosition = new Vector3(Random.Range(-10f, 10), 0, Random.Range(-10f, 10));
            Vector3 randomSpawnRotation = Vector3.up * Random.Range(0, 360);

            GameObject newChair = (GameObject)Instantiate(chairPrefab, randomSpawnPosition, Quaternion.Euler(randomSpawnRotation));
            //Instantiante(chairPrefab, randomSpawnPosition, Quaternion.Euler(randomSpawnRotation));
            newChair.transform.parent = transform;
        }

        if (Input.GetKey("tab"))
        {
            NextLevelGo();
        }
	}

    void NextLevelGo()
    {
        Application.LoadLevel(4);
    }
}
