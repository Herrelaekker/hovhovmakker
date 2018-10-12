using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public int wave;

    public int health;
    public float speed;

    public float knockback;
    public float knockbackLength;
    public float knockbackCount;

    private bool hit;

    public bool bigEnemy;
    public GameObject[] droppedEnemy;
    public Transform spawnPos;
    public float dir;

    public AudioClip hitSnd;
    public AudioClip idleSnd;

    public ParticleSystem deathParticle;

    public bool spawned;

    void Start()
    {
        if (!spawned)
        dir = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Den bevæger sig nedad med en hastighed, medmindre den er igang med at blive slet tilbage
        if (knockbackCount <= 0)
        {
            if (GameObject.Find("Main Camera").GetComponent<NextLevel>().currentWave == wave)
                transform.Translate(0, -speed * Time.deltaTime, 0);
        }
        else
        {
            transform.Translate(dir, speed * knockback, 0);
            knockbackCount -= Time.deltaTime;
        }
        //Hvis enemyen dør, dør den + tæller som død
        if (health <= 0)
        {
            Instantiate(deathParticle, spawnPos.position, spawnPos.rotation);
            if (bigEnemy)
            {

                for (int i = 0; i < droppedEnemy.Length; i++)
                {
                    droppedEnemy[i].GetComponent<Enemy>().wave = GameObject.Find("Main Camera").GetComponent<NextLevel>().currentWave;
                    droppedEnemy[i].GetComponent<Enemy>().knockbackCount = droppedEnemy[i].GetComponent<Enemy>().knockbackLength;
                    droppedEnemy[i].GetComponent<Enemy>().dir = Mathf.Pow(-0.5f,i)*i;
                    Instantiate(droppedEnemy[i], spawnPos.position, spawnPos.rotation);
                }
            }

            Destroy(gameObject);
            GameObject.Find("Main Camera").GetComponent<NextLevel>().enemiesKilled += 1;
            print(GameObject.Find("Main Camera").GetComponent<NextLevel>().enemiesKilled);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Hvis spilleren rører dette objekt
        if (other.gameObject.tag == "Player")
        {
            //Hvis den roterer
            if (other.GetComponentInChildren<Rotator>().isRotating == true)
            {
                GameObject.Find("Main Camera").GetComponent<AudioSource>().clip = hitSnd;
                GameObject.Find("Main Camera").GetComponent<AudioSource>().Play();
                //Så tager dette objekt skade
                health -= other.GetComponentInChildren<Rotator>().damage;
                hit = true;
            }

            //Hvis dette objekt stadig har liv, efter at blive skadet
            if (health > 0)
            {
                //Sætter knockbacktiden
                var player = other.GetComponent<PlayerMovement>();
                player.knockbackCount = player.knockbackLength;

                //Hvis playeren kommer fra venstre side, så ryger den til venstre
                if (other.transform.position.x < transform.position.x)
                {
                    player.knockFromRight = true;
                }
                //Hvis playeren kommer fra højre side, så ryger den til højre
                else
                {
                    player.knockFromRight = false;
                }

                //Hvis playeren kommer nedefra, så ryger den ned igen
                if (other.transform.position.y < transform.position.y)
                {
                    player.knockFromTop = true;
                }
                //Hvis playeren kommer oppefra, så ryger den op igen
                else
                {
                    player.knockFromTop = false;
                }
            }

            if (hit)
            {
                knockbackCount = knockbackLength;
                hit = false;
            }
        }

    }
}
