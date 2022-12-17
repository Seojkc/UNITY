using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainLoop : MonoBehaviour
{

    public GameObject car;
    public int laneNo = 1;

    Vector3 boundary;

    public GameObject truck;
    public int maxtruckOnRoad = 3;
    int currenttruckOnRoad = 0;

    float lastShot;

    bool playGame = true;

    public GameObject gameOverMessage;


    public AudioSource collisionSound;

    public void playCollisionSound()
    {
        collisionSound.Play();

    }

    public void stopGame()
    {
        playGame = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        boundary = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        lastShot = Time.time;
       

    }

    // Update is called once per frame
    void Update()
    {
        if (playGame)
        {
            if (Input.GetKey(KeyCode.DownArrow) && laneNo == 0)
            {
                car.transform.Translate(new Vector2(0, -3));
                laneNo = 1;

            }
            if (Input.GetKey(KeyCode.UpArrow) && laneNo == 1)
            {
                car.transform.Translate(new Vector2(0, 3));
                laneNo = 0;

            }

            if (currenttruckOnRoad < maxtruckOnRoad && (Time.time - lastShot) > 3)
            {
                createTruck();
                lastShot = Time.time;
            }

        }
        


    }
    float truckPosition1 = 1.13f;
    float truckPosition2 = 1.52f ; 




    void createTruck()
    {
        
        if(laneNo == 0)
        {
            Instantiate(truck);
            truck.transform.position = new Vector2(boundary.x, truckPosition1);

        }
        if(laneNo == 1)
        {
            Instantiate(truck);
            truck.transform.position = new Vector2(boundary.x,-1* truckPosition2);
        }
        currenttruckOnRoad++;
    }

    public void removeTruck()
    {
        currenttruckOnRoad--;
    }





}
