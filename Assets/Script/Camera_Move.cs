using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Move : MonoBehaviour
{
    public Transform target;

    public float dist = 1f;
    public float height = 5.0f;
    public float dampRotate = 0.5f;

    public float duration = 1f;
    public float magitude = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //float cur_Y_Angle = Mathf.LerpAngle(tr.eulerAngles.y, target.eulerAngles.y, dampRotate * Time.deltaTime);

        //Quaternion rot = Quaternion.Euler(0, cur_Y_Angle, 0);


        Vector3 TargetPos = new Vector3(target.transform.position.x, target.transform.position.y, this.transform.position.z);
        transform.position = Vector3.Lerp(transform.position, TargetPos, Time.deltaTime * 2);
        


       // tr.LookAt(target);
    }

    //public IEnumerator ShakeCamera(Vector3 originPos)
    //{
    //    float passTime = 0f;
    //    while (passTime < duration)
    //    {
    //        transform.localPosition = (Vector3)Random.insideUnitCircle * magitude + originPos;

    //        passTime += Time.deltaTime;
    //        yield return null;
    //    }
    //    transform.localPosition = originPos;
    //}
}
