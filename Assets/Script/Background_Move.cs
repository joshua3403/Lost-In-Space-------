using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_Move : Game_Manager
{
    private Vector3 player_pos;


    private GameObject tempobj;

    private float background_tile_x;
    private float background_tile_y;

    public Vector3 origin_pos;


    public SpriteRenderer space_tile;

    private Vector3 temp;

    // Start is called before the first frame update
    void Start()
    {

        background_tile_x = space_tile.size.x;
        background_tile_y = space_tile.size.y;
        background_tile_x *= 2;
        background_tile_y *= 2;

        origin_pos = this.transform.localPosition;
        origin_pos.z = 12; //배경으로 내려가도록
        Instantiate(space_tile, origin_pos + temp, Quaternion.identity); //가운데
        temp.x -= background_tile_x;
        temp.y += background_tile_y;
        Instantiate(space_tile, origin_pos + temp, Quaternion.identity);//왼쪽위
        temp.x += background_tile_x;
        Instantiate(space_tile, origin_pos + temp, Quaternion.identity); //위
        temp.x += background_tile_x;
        Instantiate(space_tile, origin_pos + temp, Quaternion.identity); //오른쪽 위
        temp.y -= background_tile_y;
        Instantiate(space_tile, origin_pos + temp, Quaternion.identity); //오른쪽
        temp.x -= background_tile_x;
        temp.x -= background_tile_x;
        Instantiate(space_tile, origin_pos + temp, Quaternion.identity); //왼쪽
        temp.y -= background_tile_y;
        Instantiate(space_tile, origin_pos + temp, Quaternion.identity); //왼쪽 아래
        temp.x += background_tile_x;
        Instantiate(space_tile, origin_pos + temp, Quaternion.identity); //아래
        temp.x += background_tile_x;
        Instantiate(space_tile, origin_pos + temp, Quaternion.identity); //아래 오른쪽
    }

    // Update is called once per frame
    void Update()
    {
        player_pos = Get_tr();
        temp.z = 12;//배경 으로 ㄱㄱ...

        tempobj = GameObject.FindWithTag("BackGround");
        if (tempobj != null)
        {
            if (Mathf.Abs(player_pos.y - tempobj.transform.position.y) >= 2 * background_tile_y)
                Destroy(tempobj);
            if (Mathf.Abs(player_pos.x - tempobj.transform.position.x) >= 2 * background_tile_x)
                Destroy(tempobj);
        }

        if (player_pos.y-origin_pos.y>= background_tile_y)
        {
            temp.y = origin_pos.y + 2*background_tile_y;
            temp.x = origin_pos.x - background_tile_x;
            Instantiate(space_tile, temp, Quaternion.identity); //왼쪽 위

            temp.y = origin_pos.y + 2 * background_tile_y;
            temp.x = origin_pos.x + background_tile_x;
            Instantiate(space_tile, temp, Quaternion.identity); //오른쪽 위

            temp.y = origin_pos.y + 2 * background_tile_y;
            temp.x = origin_pos.x;
            Instantiate(space_tile, temp, Quaternion.identity); //위

            origin_pos = temp;
            origin_pos.y -= background_tile_y;
            //위에 3개 만들고
        }
        if (player_pos.x - origin_pos.x >= background_tile_x) //오른쪽
        {
            temp.x = origin_pos.x + 2 * background_tile_x;
            temp.y = origin_pos.y - background_tile_y;
            Instantiate(space_tile, temp, Quaternion.identity); 

            temp.x = origin_pos.x + 2 * background_tile_x;
            temp.y = origin_pos.y + background_tile_y;
            Instantiate(space_tile, temp, Quaternion.identity);

            temp.x = origin_pos.x + 2 * background_tile_x;
            temp.y = origin_pos.y;
            Instantiate(space_tile, temp, Quaternion.identity); 

            origin_pos = temp;
            origin_pos.x -= background_tile_x;
            //오른쪽에 3개 만들고
        }
        if (player_pos.y - origin_pos.y <= -background_tile_y) //아래
        {
            temp.y = origin_pos.y - 2 * background_tile_y;
            temp.x = origin_pos.x - background_tile_x;
            Instantiate(space_tile, temp, Quaternion.identity); 

            temp.y = origin_pos.y - 2 * background_tile_y;
            temp.x = origin_pos.x + background_tile_x;
            Instantiate(space_tile, temp, Quaternion.identity); 

            temp.y = origin_pos.y - 2 * background_tile_y;
            temp.x = origin_pos.x;
            Instantiate(space_tile, temp, Quaternion.identity);

            origin_pos = temp;
            origin_pos.y += background_tile_y;
        }
        if (player_pos.x - origin_pos.x <= -background_tile_x) //왼쪽
        {
            temp.x = origin_pos.x - 2 * background_tile_x;
            temp.y = origin_pos.y - background_tile_y;
            Instantiate(space_tile, temp, Quaternion.identity);

            temp.x = origin_pos.x - 2 * background_tile_x;
            temp.y = origin_pos.y + background_tile_y;
            Instantiate(space_tile, temp, Quaternion.identity);

            temp.x = origin_pos.x - 2 * background_tile_x;
            temp.y = origin_pos.y;
            Instantiate(space_tile, temp, Quaternion.identity);

            origin_pos = temp;
            origin_pos.x += background_tile_x;
        }




        //if (ball.GetComponent<S_Move>().transform.position.x -this.space_tile.size.x>0)
        //{
        //    temp.x = space_tile.size.x;
        //    temp.y = space_tile.size.y;
        //    Instantiate(space_tile, this.transform.localPosition+temp,Quaternion.identity);
        //}


        //if (ball.GetComponent<S_Move>().transform.position.x-this.transform.position.x<-camera_size)
        //{
        //    this.transform.Translate(ball.GetComponent<S_Move>().transform.position.x - this.transform.position.x, 0, 0);
        //}
        //else if(ball.GetComponent<S_Move>().transform.position.x - this.transform.position.x > camera_size)
        //{
        //    this.transform.Translate(ball.GetComponent<S_Move>().transform.position.x - this.transform.position.x, 0, 0);

        //}

        //if (ball.GetComponent<S_Move>().transform.position.y - this.transform.position.y < -camera_size)
        //{
        //    this.transform.Translate(0, ball.GetComponent<S_Move>().transform.position.y - this.transform.position.y,0);

        //}
        //else if (ball.GetComponent<S_Move>().transform.position.y - this.transform.position.y > camera_size)
        //{
        //    this.transform.Translate(0, ball.GetComponent<S_Move>().transform.position.y - this.transform.position.y,0);

        //}
    }
}
