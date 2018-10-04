using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour {

    public int enemiesKilled;
    public int enemiesToKill;

    private int nextSceneIndex;


	// Use this for initialization
	void Start () {

        enemiesKilled = 0;
        nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
	}
	
	// Update is called once per frame
	void Update () {
	
        if (enemiesKilled >= enemiesToKill)
        {
            if (SceneManager.sceneCountInBuildSettings > nextSceneIndex)
            {
                SceneManager.LoadScene(nextSceneIndex);
            }
        }
	}
}
