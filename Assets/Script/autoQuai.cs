using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoQuai : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed;
    public float distance;
    private bool movingRight = true;
    public Transform groundDetection;
    public bool nen;
    void Start()
    {
        
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "nen1")
        {
            nen = true;
        }
        else if(col.gameObject.tag == "nen2")
        {
            nen = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(nen == false)
        {
            transform.localScale = new Vector3(6, 6, 0);
            transform.Translate(Vector2.right * speed * Time.deltaTime * -10f);
        }
        else if(nen == true) {
            transform.localScale = new Vector3(-6, 6, 0);
            transform.Translate(Vector2.right * speed * Time.deltaTime * 10f);
        }
            
       
    }
}
