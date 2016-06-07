using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeGame : MonoBehaviour
{
    // this code is from the tutorial on youtube by Sebastion Langue, his Introduction to Game Development E06

    public Text timeWanted;
    public Text resultTime;
    float roundStartDelayTime = 3;

    float roundStartTime;
    int waitTime;
    bool roundStarted;

    // Use this for initialization
    void Start()
    {
        print("Press the spacebar once you think the alloted time is up.");
        Invoke("SetNewRandomTime", roundStartDelayTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && roundStarted)
        {
            InputReceived();
        }

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
        if (Input.GetKey("tab"))
        {
            NextLevelGo();
        }

        SetTimeWanted();
    }

    void InputReceived()
    {
        roundStarted = false;
        float playerWaitTime = Time.time - roundStartTime;
        float error = Mathf.Abs(waitTime - playerWaitTime);

        resultTime.text = "You waited for " + playerWaitTime + " seconds. That's " + error + " seconds off. " + GenerateMessage(error) + "\n\nA new time will be generated. Thank you for playing!" ;
        Invoke("SetNewRandomTime", roundStartDelayTime);
    }

    string GenerateMessage(float error)
    {
        string message = "";
        if (error < .15f)
        {
            message = "Outstanding!";
        }
        else if (error < .75f)
        {
            message = "Exceeds Expectations.";
        }
        else if (error < 1.25f)
        {
            message = "Acceptable.";
        }
        else
        {
            message = "Not Very Good.";
        }
        return message;
    }

    void SetNewRandomTime()
    {
        waitTime = Random.Range(5, 21);
        roundStartTime = Time.time;
        roundStarted = true;

        print(waitTime + " seconds.");
    }

    void NextLevelGo()
    {
        Application.LoadLevel(2);
    }

    void SetTimeWanted()
    {
        timeWanted.text = "Wait " + waitTime.ToString () + " seconds, and then press spacebar when you think it has passed.";
    }    
}
