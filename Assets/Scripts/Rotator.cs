using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Rotator : MonoBehaviour
{
    public float fuelUse;
    public float fuelGain;

    public float speed;
    public int damage;

    public bool isRotating;
    public bool isCharging;

    //Update is called every frame
    void Update()
    {
        //når man trykker på knappen
        if (Input.GetButton("Fire1") && !isCharging)
        {
            //finder FuelMeterets BarScript -> Hvis Der er mere fuel end 0
            if (GameObject.Find("FuelMeter").GetComponent<BarScript>().fillAmount > 0)
            {
                //så roterer den
                transform.Rotate(new Vector3(0, 0, speed) * Time.deltaTime);
                //så bruger den fuel
                GameObject.Find("FuelMeter").GetComponent<BarScript>().fillAmount -= fuelUse;
                isRotating = true;
            }
            else
            {
                isRotating = false;
            }
        }
        //ellers hvis man ikke har maximum fuel
        else if (GameObject.Find("FuelMeter").GetComponent<BarScript>().fillAmount < 100)
        {
            //så får man mere fuel
            GameObject.Find("FuelMeter").GetComponent<BarScript>().fillAmount += fuelGain;
            isRotating = false;
        }

        if (GameObject.Find("FuelMeter").GetComponent<BarScript>().fillAmount <= 0)
        {
            isCharging = true;
            GameObject.Find("Content").GetComponent<Image>().color = new Color(255,0,0,255);
        }
        else if (GameObject.Find("FuelMeter").GetComponent<BarScript>().fillAmount >= 100)
        {
            isCharging = false;
            GameObject.Find("Content").GetComponent<Image>().color = new Color(255, 255, 255, 255);
        }
    }
}