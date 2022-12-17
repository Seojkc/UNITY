using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainLoop : MonoBehaviour
{

    public GameObject car;
    public int roadLine = 2;

    Vector3 boundary;

    public GameObject Obstruction;
    public int maximumObstruction = 3;
    int currentObstruction = 0;

    float lastShot, lastCar;

    //bool playGame = true;

    //public GameObject gameOverMessage;


    public AudioSource collisionSound;

    public void playCollisionSound()
    {
        collisionSound.Play();

    }

    bool game = true;

    public void Game()
    {
        game = false;
    }

   

    // Start is called before the first frame update
    void Start()
    {
        boundary = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        lastShot = Time.time;
        lastCar = Time.time;



    }

    // Update is called once per frame
    void Update()
    {
        if (game)
        {
            if ((Time.time - lastShot) > 0.1)
            {
                if (Input.GetKey(KeyCode.LeftArrow) && roadLine > -4)
                {

                    car.transform.Translate(new Vector2(-3, 0));
                    roadLine -= 3;

                }
                if (Input.GetKey(KeyCode.RightArrow) && roadLine < 6)
                {
                    car.transform.Translate(new Vector2(3, 0));
                    roadLine += 3;

                }
                lastShot = Time.time;


            }


            if (currentObstruction < maximumObstruction && (Time.time - lastCar) > 1)
            {
                Debug.Log("ksdhbgfk");
                createObstruction();
                currentObstruction++;
                lastCar = Time.time;

            }

        }
        
        
        


    }

    public int lives = 3;

    public int getLives()
    {
        return lives;
    }
    
    public void setLives()
    {
        lives -= 1;
    }



    void createObstruction()
    {
        float X = Random.Range(-8,8);

        float positionX=0;
        if (X>6.3)
        {
            positionX = 8.0f;
        }
        else if (X >3.4)
        {
            positionX = 5.0f;
        }
        else if (X > 0)
        {
            positionX = 1.5f;
        }
        else if (X > -3.2)
        {
            positionX = -1.8f;
        }
        else 
        {
            positionX = -5.3f;
        }
        




        Instantiate(Obstruction);
        Obstruction.transform.position = new Vector2(positionX, boundary.y);
        
    }

    public void removeObstruction()
    {
        currentObstruction--;
    }





}
