using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Partical_Move : Game_Manager
{
    public GameObject obj;

    public float delay_time = 2.0f;

    ParticleSystem particle_system;

    // Start is called before the first frame update
    void Start()
    {
        particle_system = GetComponent<ParticleSystem>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = obj.transform.position;
        float temp_time = 0;

        if (Get_dead())
        {
            while(temp_time<delay_time)
            {
                temp_time += Time.deltaTime;
            }
            particle_system.Stop();
            
        }
    }
}
