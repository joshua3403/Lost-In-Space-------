using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Move : Game_Manager
{
    public static float deg = 0;
    float rad;
    bool flag = false;
    public float speed = 10f;
    public float radius = 1f;
    Vector2 vec;
    public GameObject obj = null;
    public GameObject snake;
    Transform trans;
    public bool is_destroy=false;

    private void Start()
    {
        trans = obj.GetComponent<Transform>();
    }
    void Update()
    {

        Set_tr(this.transform.position);

        
        if (is_destroy)
        {

        }
        else
        {
            if (flag)
            {
                deg -= Time.deltaTime * speed;
                this.transform.Rotate(0, 0, -Time.deltaTime * speed);
            }
            else
            {
                deg += Time.deltaTime * speed;
                this.transform.Rotate(0, 0, Time.deltaTime * speed);

            }
            rad = (float)deg * Mathf.PI / 180;
            vec = new Vector2(trans.position.x + radius * Mathf.Cos(rad), trans.position.y + radius * Mathf.Sin(rad));
            this.transform.position = vec;


        }
    }
    public void Change_degree(float val)
    {
        deg += val;
        if (flag)
            flag = false;
        else
            flag = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        is_destroy = true;
        if (snake == null) return;
        snake.SetActive(false);
    }
}