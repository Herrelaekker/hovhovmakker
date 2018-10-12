using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoseHealth : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            //bliver nødt til at finde objectet v
            GameObject.Find("EventSystem").GetComponent<UI>().health -= 1;
            other.GetComponent<Enemy>().health = 0;

            if (GameObject.Find("EventSystem").GetComponent<UI>().health <= 0)
            {
                Scene LoadedLevel = SceneManager.GetActiveScene();
                SceneManager.LoadScene(LoadedLevel.buildIndex);
            }
        }
    }
}
