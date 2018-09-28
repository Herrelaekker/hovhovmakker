using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour
{

    public float speed;

    //Update is called every frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            transform.Rotate(new Vector3(0, 0, speed) * Time.deltaTime);
        }
    }
}
