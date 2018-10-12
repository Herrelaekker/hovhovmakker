using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour {

    public int enemiesKilled;
    public int[] enemiesToKill;

    public int currentWave;
    public int finalWave;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
        if (enemiesKilled >= enemiesToKill[currentWave])
        {
            currentWave += 1;
            enemiesKilled = 0;
            GameObject.Find("EventSystem").GetComponent<UI>().waveTimer = GameObject.Find("EventSystem").GetComponent<UI>().startWaveTimer;

            if (currentWave > finalWave)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
	}
}
