using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{

    float roundStartTime; //7
    int waitTime; //3

    // Use this for initialization
    void Start()
    {
        print("Press the SPACE button, when allotted time is up"); //1
        SetNewRandomTime(); //6
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        { //9
            float playerWaitTime = Time.time - roundStartTime; //10 num of seconds since the start of the game
            print(playerWaitTime + " seconds."); //11
            Renderer CubeColor = GetComponent<Renderer>();
            
            float result = Mathf.Abs(playerWaitTime - waitTime);
            print(result);

            if (result < 1f)
            {
                print("You are doing well");
                CubeColor.material.color = new Color(0, 255, 0, 255);
            }
            else
            {
                print("You may do it better. Come on!");
                CubeColor.material.color = new Color(255, 0, 0, 255);
            }
            SetNewRandomTime();
        }
    }

    void SetNewRandomTime()
    { //2
        waitTime = Random.Range(4, 10); //4
        roundStartTime = Time.time; //8
        print("Wait Time is " + waitTime + " seconds."); //5
    }
}
