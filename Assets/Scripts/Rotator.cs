using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour
{
    public float fuelUse;
    public float fuelGain;

    public float speed;

    public int damage;

    public bool isRotating;

    //Update is called every frame
    void Update()
    {
        //når man trykker på knappen
        if (Input.GetMouseButton(0))
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
                isRotating = false;
        }
        //ellers hvis man ikke har maximum fuel
        else if (GameObject.Find("FuelMeter").GetComponent<BarScript>().fillAmount < 100)
        {
            //så får man mere fuel
            GameObject.Find("FuelMeter").GetComponent<BarScript>().fillAmount += fuelGain;
            isRotating = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy" && isRotating)
        {

        }
    }
}