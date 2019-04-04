using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    enum Level
    {
        NONE = -1,
        LEVEL_1 = 0,
        LEVEL_2,
        LEVEL_3,
        LEVEL_4,
        LEVEL_5,
        LEVEL_6,
        LEVEL_7,
        LEVEL_8,
        LEVEL_9,
        LEVEL_10,
        LEVEL_11,
        NUM
    };

    public static int Screen_x = 46;
    public static int Screen_y = 36;

    public GameObject Enemy_1;
    public GameObject Enemy_2;
    public GameObject Enemy_3;
    public GameObject Enemy_4;
    public GameObject Enemy_5;
    public GameObject Enemy_6;
    public GameObject Enemy_7;
    public GameObject Enemy_8;
    public GameObject Enemy_9;
    public GameObject Enemy_10;
    public GameObject Enemy_11;

    public GameObject Center;

    GameObject[] existEnemys;
    public int maxEnemy = 50;
    Vector3[] prefab_pos;
    Vector3 Position;
    Vector3 center_Pos;

    // Start is called before the first frame update
    void Start()
    {
        existEnemys = new GameObject[maxEnemy];
        prefab_pos = new Vector3[maxEnemy];
        
        // 코루틴을 사용하여 주기적으로 함수를 실행한다.
        StartCoroutine(Exec());
    }

    IEnumerator Exec()
    {
        while (true)
        {
            Generate();
            yield return new WaitForSeconds(1.0f);
        }
    }

    void Generate()
    {
        for (int enemyCount = 0; enemyCount < existEnemys.Length; ++enemyCount)
        {
            Position = prefab_pos[enemyCount];
            //print(Position);
            if(Position.x<-6||Position.x > 6 || Position.y >6 || Position.y < -6)
            {
                if (existEnemys[enemyCount] == null)
                {
                    int level = Random.Range((int)Level.LEVEL_1, (int)Level.NUM);
                    {
                        if (level == (int)Level.LEVEL_1)
                        {
                            existEnemys[enemyCount] = Instantiate(Enemy_1, Position, Quaternion.identity) as GameObject;
                        }

                        else if (level == (int)Level.LEVEL_2)
                        {
                            existEnemys[enemyCount] = Instantiate(Enemy_2, Position, Quaternion.identity) as GameObject;

                        }
                        else if (level == (int)Level.LEVEL_3)
                        {
                            existEnemys[enemyCount] = Instantiate(Enemy_3, Position, Quaternion.identity) as GameObject;

                        }
                        else if (level == (int)Level.LEVEL_4)
                        {
                            existEnemys[enemyCount] = Instantiate(Enemy_4, Position, Quaternion.identity) as GameObject;
                        }
                        else if (level == (int)Level.LEVEL_5)
                        {
                            existEnemys[enemyCount] = Instantiate(Enemy_5, Position, Quaternion.identity) as GameObject;
                        }
                        else if (level == (int)Level.LEVEL_6)
                        {
                            existEnemys[enemyCount] = Instantiate(Enemy_6, Position, Quaternion.identity) as GameObject;
                        }
                        else if (level == (int)Level.LEVEL_7)
                        {
                            existEnemys[enemyCount] = Instantiate(Enemy_7, Position, Quaternion.identity) as GameObject;
                        }
                        else if (level == (int)Level.LEVEL_8)
                        {
                            existEnemys[enemyCount] = Instantiate(Enemy_8, Position, Quaternion.identity) as GameObject;
                        }
                        else if (level == (int)Level.LEVEL_9)
                        {
                            existEnemys[enemyCount] = Instantiate(Enemy_9, Position, Quaternion.identity) as GameObject;
                        }
                        else if (level == (int)Level.LEVEL_10)
                        {
                            existEnemys[enemyCount] = Instantiate(Enemy_10, Position, Quaternion.identity) as GameObject;
                        }
                        else 
                        {
                            existEnemys[enemyCount] = Instantiate(Enemy_11, Position, Quaternion.identity) as GameObject;
                        }
                    }
                }
            //this.Position.position = prefab_pos[enemyCount];
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        getRandomVec();
        center_Pos = Center.GetComponent<Transform>().position;
    }

    void getRandomVec()
    {
        bool isSame;
        Vector2 temp;

        for (int i = 0; i < prefab_pos.Length; ++i)
        {
            while (true)
            {
                temp = new Vector2(center_Pos.x + +Random.Range(-Screen_x, Screen_x), center_Pos.y + Random.Range(-Screen_y, Screen_y));

                if (Mathf.Abs(temp.x - center_Pos.x) > 3 || Mathf.Abs(temp.y - center_Pos.y) > 3)
                    prefab_pos[i] = temp;


                isSame = false;

                for(int j = 0; j < i; ++j)
                {
                    if(prefab_pos[j] == prefab_pos[i])
                    {
                        isSame = true;
                        break;
                    }
                }
                if (!isSame)
                    break;
            }
        }
    }

    

}
