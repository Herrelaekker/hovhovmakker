using UnityEngine;
using System.Collections;

public class PlayerDamage : MonoBehaviour {

    public int damage;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy" && Input.GetMouseButton(0))
        {
            other.GetComponent<Enemy>().health -= damage;
        }
    }
}
