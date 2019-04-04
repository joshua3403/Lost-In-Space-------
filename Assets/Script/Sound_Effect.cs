using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Effect : MonoBehaviour
{
    private AudioSource audiosource;

    public AudioClip CrushSound;
    // Start is called before the first frame update
    void Start()
    {
        this.audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        this.audiosource.Play();
    }
}
