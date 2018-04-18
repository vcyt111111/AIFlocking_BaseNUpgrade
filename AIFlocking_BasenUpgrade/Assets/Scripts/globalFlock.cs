using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class globalFlock : MonoBehaviour {
    public GameObject playerPrefab;
    public static int tankSize = 6;

    static int numPlayer = 30;
    public static GameObject[] allPlayers = new GameObject[numPlayer];

    public static Vector2 goalPos = Vector2.zero;

	// Use this for initialization
	void Start () {
		for(int i = 0; i < numPlayer; i++)
        {
            Vector2 pos = new Vector2(Random.Range(-tankSize, tankSize),
                                      Random.Range(-tankSize, tankSize));
            allPlayers[i] = (GameObject)Instantiate(playerPrefab, pos, Quaternion.identity);
        }
	}
	
	// Update is called once per frame
	void Update () {
		if(Random.Range(0, 10000) < 50)
        {
            goalPos = new Vector2(Random.Range(-tankSize, tankSize),
                                  Random.Range(-tankSize, tankSize));
        }
	}
}
