using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public int health;
    public float speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        transform.Translate(0, -speed * Time.deltaTime, 0);

        if (health <= 0)
        {
            Destroy(gameObject);
        }
	}
}
