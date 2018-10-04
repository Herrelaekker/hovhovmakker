using UnityEngine;
using System.Collections;

public class LoseHealth : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            //bliver nødt til at finde objectet v
            GameObject.Find("EventSystem").GetComponent<UI>().health -= 1;
            other.GetComponent<Enemy>().health = 0;
        }
    }
}
