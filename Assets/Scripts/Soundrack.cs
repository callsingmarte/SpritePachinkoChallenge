using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soundrack : MonoBehaviour
{
    AudioSource soundrack;
    [SerializeField] AudioClip[] clips;
    int clipNumber = 0;
    // Start is called before the first frame update
    void Start()
    {
        soundrack = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!soundrack.isPlaying)
        {
            if(clipNumber < clips.Length)
            {
                soundrack.PlayOneShot(clips[clipNumber]);
                clipNumber++;
            }
            else
            {
                clipNumber = 0;
                soundrack.PlayOneShot(clips[clipNumber]);
            }
        }
    }
}
