using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class UI : MonoBehaviour {

    public Text healthText;
    public int health;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        healthText.text = "Health: " + health;
	}
}
