using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour {

    public int enemiesKilled;
    public int[] enemiesToKill;

    public int currentWave;

	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
	
        if (enemiesKilled >= enemiesToKill[currentWave - 1])
        {
            currentWave += 1;
            enemiesKilled = 0;
        }
	}
}
