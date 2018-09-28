using UnityEngine;
using System.Collections;

public class LoseHealth : MonoBehaviour {

    public int health;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            GameObject.Find("EventSystem").GetComponent<UI>().health -= 1;
            Destroy(other.gameObject);
        }
    }
}
