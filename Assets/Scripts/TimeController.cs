using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    public CountDownController CountDown;
    public Delivery manager;
    public float GameTime = 30;
    public Text GameTimeText;
    
    private void Update()
    {
       if(CountDown.IsGameStart == true)
       {
            GameTime -= Time.deltaTime;
            GameTimeText.text = "Time: " + (int)GameTime;
        }
       if ((int)GameTime == 0)
        {
            manager.GameOver();
            CountDown.IsGameStart = false;
        }
       



    }

}
