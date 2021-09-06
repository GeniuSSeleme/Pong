using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstScript : MonoBehaviour
{
    
    float r = 1.2f;
    public int x = 0;

    //string Username = "ada";
    //bool Wine = false;
    Vector2  position;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello World!");
        Debug.Log("ada");
        //Wine = true;
        Debug.Log("You Win");
        
        
       

        Debug.Log(r);

        position.x = x;
        position.y = 2;
        Debug.Log(x);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Hello World!");
        float x = Input.GetAxis("Horizontal");
        Debug.Log(x);
    }
}  














       

          




