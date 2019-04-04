using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brake_effec : MonoBehaviour
{
    public float play_time=3.0f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, play_time);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
