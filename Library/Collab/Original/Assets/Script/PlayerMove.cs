using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    
    public Rigidbody2D obj = null;

    private Vector2 ball_temp;

    public GameObject s_move;

    private Vector2 temp;

    private bool flag;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
       
                if (Input.GetMouseButtonDown(0)&&Input.mousePosition.x<Screen.width/2)
                {
                    
                    if (flag)
                        flag = false;
                    else
                        flag = true;
                }

                if (Input.GetMouseButtonDown(0)&& Input.mousePosition.x > Screen.width / 2)
                {
                    if (flag)
                    {
                        ball_temp = obj.transform.position;

                        s_move.GetComponent<S_Move>().Change_degree(60);

                        temp.x = (ball_temp.x + this.transform.position.x) / 2 - ((Mathf.Sqrt(3) * (this.transform.position.y - ball_temp.y))) / 2;
                        temp.y = (ball_temp.y + this.transform.position.y) / 2 + ((Mathf.Sqrt(3) * (this.transform.position.x - ball_temp.x))) / 2;


                        this.transform.position = (temp);
                    }
                    else
                    {
                        ball_temp = obj.transform.position;

                        s_move.GetComponent<S_Move>().Change_degree(300);

                        temp.x = (ball_temp.x + this.transform.position.x) / 2 + ((Mathf.Sqrt(3) * (this.transform.position.y - ball_temp.y))) / 2;
                        temp.y = (ball_temp.y + this.transform.position.y) / 2 - ((Mathf.Sqrt(3) * (this.transform.position.x - ball_temp.x))) / 2;


                        this.transform.position = (temp);
                    }
                }
        
    }
}
