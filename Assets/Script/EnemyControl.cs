using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public Camera mainCamera;
    private float CAMERA_WIDTH = 50;
    private float CAMERA_HEIGHT = 50;
    Vector3 camera_Pos;
    Vector3 object_Pos;
    Vector3 temp1;
    Vector3 temp2;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;

        object_Pos = this.gameObject.GetComponent<Transform>().position;

    }

    // Update is called once per frame
    void Update()
    {
        camera_Pos = mainCamera.transform.position;
        temp1 = camera_Pos + new Vector3(CAMERA_WIDTH, CAMERA_HEIGHT);
        temp2 = camera_Pos - new Vector3(CAMERA_WIDTH, CAMERA_HEIGHT);

        if (object_Pos.x>temp1.x||object_Pos.y>temp1.y||object_Pos.x<temp2.x||object_Pos.y<temp2.y)
        {
            Destroy(this.gameObject);
        }
    }


    //private void OnBecameInvisible()
    //{
    //    Destroy(this.gameObject);
    //    print("Destroying");
    //}
}
