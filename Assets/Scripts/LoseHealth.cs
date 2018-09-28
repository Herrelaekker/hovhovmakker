using UnityEngine;
using System.Collections;

public class LoseHealth : MonoBehaviour {

    public int health;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            //bliver nødt til at finde objectet v
            GetComponent<UI>().health -= 1;
            Destroy(other.gameObject);
        }
    }
}
