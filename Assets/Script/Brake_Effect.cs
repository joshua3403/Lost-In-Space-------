using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brake_Effect : Game_Manager
{
    public GameObject brake_prefab;

    public GameObject camera_brake;

    private Camera_Move camera_move;

    public float x_var;

    private Vector3 originPos;

    private AudioSource audiosource;


    // Start is called before the first frame update
    void Start()
    {
        this.audiosource = GetComponent<AudioSource>();
        camera_move = camera_brake.GetComponent<Camera_Move>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
            this.audiosource.Play();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        originPos = this.transform.position;
        Vector3 temp = this.transform.position;
        temp.z = -1;
        temp.x -= x_var;
        if (collision.gameObject.tag == "enemy")
        {
            Instantiate(brake_prefab, temp, Quaternion.identity);
            Set_dead(true);
            

            //StartCoroutine(camera_move.ShakeCamera(originPos));
        }
    }

}
