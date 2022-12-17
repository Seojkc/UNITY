using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class obstruction : MonoBehaviour
{

    float currentSpeed;
    Vector3 boundary;

    public Text gameOver;


    private mainLoop loopScript = GameObject.Find("main Camera").GetComponent<mainLoop>();

    // Start is called before the first frame update
    void Start()
    {
        boundary = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        currentSpeed = Random.Range(2,5);

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > -boundary.y - GetComponent<SpriteRenderer>().bounds.size.y / 2)
            transform.Translate(new Vector3(0, -1, 0) * currentSpeed * Time.deltaTime);
        else if (transform.position.y <= -boundary.y + GetComponent<SpriteRenderer>().bounds.size.y / 2)
        {
            Debug.Log("koppe");
            loopScript = GameObject.Find("Main Camera").GetComponent<mainLoop>();
             loopScript.removeObstruction();
             Destroy(this.gameObject);
        }
        else {
            Debug.Log("ksdhbgfk");
        }

    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        loopScript = GameObject.Find("Main Camera").GetComponent<mainLoop>();

        if (collision.gameObject.tag == "Player" && loopScript.lives == 1)
        {
            
            loopScript.playCollisionSound();
            
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
            loopScript.Game();
            gameOver.text = "Game Over";

            Application.Quit();

            //loopScript.removeTruck();*/

        }
        else
        {
            loopScript.lives -= 1;
            gameOver.text = "Lives : "+ loopScript.lives;
            Destroy(this.gameObject);
            loopScript.playCollisionSound();

        }

    }
}
