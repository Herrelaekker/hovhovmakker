using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public string[] audioName;
    public AudioClip[] audioClip;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //når denne void bliver kaldt (med et navn)-
    public void Play(string clipName)
    {
        //Så checker den hvert lydklip i arrayet
        for (int i=0; i < audioName.Length; i++)
        {
            //Hvis navne matcher
            if (clipName == audioName[i])
            {
                //spiller den klippet
                gameObject.GetComponent<AudioSource>().clip = audioClip[i];
                gameObject.GetComponent<AudioSource>().Play();
                break;
            }
        }
    } 
}
