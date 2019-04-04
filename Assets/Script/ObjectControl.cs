using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectControl : MonoBehaviour
{

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            Destroy(this.gameObject);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Game_Manager>().addTimeCount();
            Destroy(this.gameObject);
        }
    }
}
