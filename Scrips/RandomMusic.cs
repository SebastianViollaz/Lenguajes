using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMusic : MonoBehaviour
{
    public AudioClip[] Music;
    public AudioSource Audio;
    int LastNumber;
    void Start()
    {
        
    }



    // Update is called once per frame
    void Update()
    {
        if (Audio.isPlaying == false)
        {
            int RandInt = Random.Range(0, Music.Length);

            if(RandInt != LastNumber)
            {
                Audio.clip = Music[RandInt];
                Audio.Play();
                LastNumber = RandInt;
            }
          
        }
    }
}
