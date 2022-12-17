using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class appleScript1 : MonoBehaviour
{

    Vector3 boundary;


    float appleAliveTime ;

    private mainLoop loopScript = GameObject.Find("main Camera").GetComponent<mainLoop>();

    // Start is called before the first frame update
    void Start()
    {
        boundary = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        appleAliveTime = Time.time;

    }

    // Update is called once per frame
    void Update()
    {
        if ((Time.time - appleAliveTime) > 5)
        {
            
            
            loopScript = GameObject.Find("Main Camera").GetComponent<mainLoop>();
           
            appleAliveTime = Time.time;

        }
       

    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        loopScript = GameObject.Find("Main Camera").GetComponent<mainLoop>();

      //  Debug.Log("kalapila");

        if (collision.gameObject.tag == "Player")
        {
            
            
            loopScript.playCollisionSound();
            
            Destroy(this.gameObject);
            loopScript.removeApple();

            loopScript.setScore();
            
        }



    }
}
