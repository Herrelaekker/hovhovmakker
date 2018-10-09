using UnityEngine;
using System.Collections;

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
        if (Input.GetMouseButton(0) && !isCharging)
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
        }
        else if (GameObject.Find("FuelMeter").GetComponent<BarScript>().fillAmount >= 100)
        {
            isCharging = false;
        }
    }
}