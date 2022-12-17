using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car2 : MonoBehaviour
{

   
    float currentSpeed;
    Vector3 boundary;
    

    private mainLoop loopScript = GameObject.Find("main Camera").GetComponent<mainLoop>();

    // Start is called before the first frame update
    void Start()
    {
        boundary = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        currentSpeed = 3;

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > -boundary.x - GetComponent<SpriteRenderer>().bounds.size.x / 2)
            transform.Translate(new Vector3(-1, 0, 0) * currentSpeed * Time.deltaTime);
        else if (transform.position.x <= -boundary.x - GetComponent<SpriteRenderer>().bounds.size.x / 2)
        {
           /* loopScript = GameObject.Find("Main Camera").GetComponent<mainLoop>();
            loopScript.removeTruck();
            Destroy(this.gameObject);*/
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            /*loopScript = GameObject.Find("Main Camera").GetComponent<mainLoop>();
            loopScript.playCollisionSound();
            loopScript.stopGame();
            Destroy(this.gameObject);
            Destroy(collision.gameObject);

            Application.Quit();

            loopScript.removeTruck();*/
 
        }
    }
}
