using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text ScoreText;
    void Update()
    {
        ScoreText.text = "Box : " + Delivery.Instance.BoxScore;
    }

}