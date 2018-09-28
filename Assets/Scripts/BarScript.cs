using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class BarScript : MonoBehaviour {

    public float fillAmount;

    public Image content;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        Handlebar();	
	}

    private void Handlebar()
    {
        content.fillAmount = Map(fillAmount,0,100,0,1);
    }

    private float Map(float value, float inMin, float inMax, float outMin, float outMax)
    {
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
        //(78 - 0) * (1 - 0) / (230 - 0) + 0;
        //   78   * 1 / 230 = 0,339
    }
}
