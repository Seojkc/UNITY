using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class mainLoop : MonoBehaviour
{

    public GameObject apple;

    public GameObject snake;

    public Text gameOverText;

    Vector3 boundary;

    public GameObject Obstruction;
    public int maxApple = 3;
    int currentApple = 0;

    float appleAliveTime;

    


    public AudioSource eatAppleSound;

    public void playCollisionSound()
    {
        eatAppleSound.Play();

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
        appleAliveTime = Time.time;



    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.DownArrow) && snake.transform.position.y > -2.5)
            snake.transform.Translate(new Vector2(0, -1) * 4 * Time.deltaTime);
        if (Input.GetKey(KeyCode.UpArrow) && snake.transform.position.y < 2.5)
            snake.transform.Translate(new Vector2(0, 1) * 4 * Time.deltaTime);
        if (Input.GetKey(KeyCode.RightArrow) && snake.transform.position.x < 5  )
            snake.transform.Translate(new Vector2(1, 0) * 4 * Time.deltaTime);
        if (Input.GetKey(KeyCode.LeftArrow) && snake.transform.position.x > -5)
            snake.transform.Translate(new Vector2(-1, 0) * 4 * Time.deltaTime);

        
            if (Input.GetKey(KeyCode.Space))
            {
                Application.Quit();
            }


            if (currentApple < maxApple )
            {
                
                
                createApple();
                currentApple++;
                appleAliveTime = Time.time;

            }
    }

    public int lives = 3;

    public int score = 0;


    

    public void setScore()
    {
        score += 5;
        gameOverText.text = "Score : " + score;
    }



    void createApple()
    {
        

        Instantiate(apple);
        apple.transform.position = new Vector2(Random.Range(-5, 5), Random.Range(2, -2));
        
    }

    public void removeApple()
    {
        currentApple--;
    }





}
