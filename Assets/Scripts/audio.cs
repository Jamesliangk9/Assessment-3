using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class audio : MonoBehaviour
{
    public AudioSource intro;
    public AudioSource ghostNormal;
    private void Awake()
    {
        intro.Play();
    }
    private void Update()
    {
        if (intro.isPlaying == false)
        {
            ghostNormal.Play();
        }
    }
}
