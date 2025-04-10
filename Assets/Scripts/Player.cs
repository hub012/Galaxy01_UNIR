using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 5.0f;
     void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        transform.Translate(Vector2.right * (horizontal * (speed * Time.deltaTime)));
        transform.Translate(Vector2.up * (vertical * (speed * Time.deltaTime)));
            
       /* if (Input.GetKeyDown(KeyCode.UpArrow))
        {
           //transform.Translate(new Vector2(0,1));
           transform.Translate(Vector2.up * (speed * Time.deltaTime));
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            //transform.Translate(new Vector2(0,-1));
            transform.Translate(Vector2.down * (speed * Time.deltaTime));
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //transform.Translate(new Vector2(-1, 0));
            transform.Translate(Vector2.left * (speed * Time.deltaTime));
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //transform.Translate(new Vector2(1, 0));
            transform.Translate(Vector2.right * (speed * Time.deltaTime));
        }*/
    }
}
