using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

    public int health;
    public float speed;

    // Update is called once per frame
    void Update()
    {

        transform.Translate(0, -speed * Time.deltaTime, 0);

        if (health <= 0)
        {
            Destroy(gameObject);
            GameObject.Find("Main Camera").GetComponent<NextLevel>().enemiesKilled += 1;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (other.GetComponentInChildren<Rotator>().isRotating == true)
            {
                health -= other.GetComponentInChildren<Rotator>().damage;
            }


            if (health > 0)
            {
                var player = other.GetComponent<PlayerMovement>();
                player.knockbackCount = player.knockbackLength;

                if (other.transform.position.x < transform.position.x)
                    player.knockFromRight = true;
                else
                    player.knockFromRight = false;

                if (other.transform.position.y < transform.position.y)
                    player.knockFromTop = true;
                else
                    player.knockFromTop = false;
            }
        }
    }

}
