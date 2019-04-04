using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    public float ScrollSpeed = 0.5f;
    public float offset;
    private Material thisMaterial;
    // Start is called before the first frame update
    private void Start()
    {
        thisMaterial = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        offset = Time.deltaTime * ScrollSpeed;
        thisMaterial.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
}
