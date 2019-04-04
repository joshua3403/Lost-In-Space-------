using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCreater : MonoBehaviour
{
    public GameObject CO2;
    public GameObject Center;

    GameObject[] existCO2;

    Vector3 temp;
    Vector3 center_Pos;


    private int maxCO2 = 20;
    public static int Screen_x = 46;
    public static int Screen_y = 36;



    // Start is called before the first frame update
    void Start()
    {
        existCO2 = new GameObject[maxCO2];
        // 코루틴을 사용하여 주기적으로 함수를 실행한다.
        StartCoroutine(Exec());
    }

    IEnumerator Exec()
    {
        while (true)
        {
            Generate();
            yield return new WaitForSeconds(2.0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        center_Pos = Center.GetComponent<Transform>().position;
    }

    void Generate()
    {
        for(int CO2Count = 0; CO2Count < existCO2.Length; ++CO2Count)
        {
            temp = new Vector2(center_Pos.x + Random.Range(-Screen_x, Screen_x), center_Pos.y + Random.Range(-Screen_y, Screen_y));
            if(Mathf.Abs(temp.x - center_Pos.x) > 14 || Mathf.Abs(temp.x - center_Pos.y) > 8)
            {
                if ((existCO2[CO2Count] == null))
                {
                    existCO2[CO2Count] = Instantiate(CO2, temp, Quaternion.identity) as GameObject;
                }
            }

        }
    }






}
