using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class K_Move : MonoBehaviour
{
    public GameObject snake;
    private Rigidbody2D rigid_snake;
    public float radius=1f;
    private float rand;
    public float rand_range=0.01f;
    public float speed;
    Vector2 speed_temp;
    
    // Start is called before the first frame update
    void Start()
    {
        //GameObject obj = (GameObject)Instantiate(snake, transform.position, transform.rotation);
        rigid_snake=snake.GetComponent<Rigidbody2D>();
        rigid_snake.mass = radius;
        rigid_snake.velocity = new Vector3(0,1,0);
        //obj.transform.parent = transform;
        //snake.GetComponent<Transform>();
       // PlaceSnake(snake);
    }

    // Update is called once per frame
    void Update()
    {
        //snake.transform.Translate(Time.deltaTime, 0, 0, Space.World);
        rand = Random.Range(-rand_range, rand_range);
        



        if (Input.GetMouseButton(0))
        {
            speed_temp = rigid_snake.velocity;
            speed_temp.Normalize();
           // rigid_snake.velocity = new Vector2(speed_temp.x+ rand, speed_temp.y+ rand);
            rigid_snake.velocity = new Vector2(speed_temp.x, speed_temp.y);
            speed_temp = new Vector2(rigid_snake.velocity.y, -rigid_snake.velocity.x);
            rigid_snake.AddForce(speed_temp*speed);

        }
        else
        {
            speed_temp = rigid_snake.velocity;
            speed_temp.Normalize();
            // rigid_snake.velocity = new Vector2(speed_temp.x+ rand, speed_temp.y + rand);
            rigid_snake.velocity = new Vector2(speed_temp.x, speed_temp.y);
            speed_temp = new Vector2(-rigid_snake.velocity.y, rigid_snake.velocity.x);
            rigid_snake.AddForce(speed_temp* speed);

        }
    }

}
