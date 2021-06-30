using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
  public Text timeLabel;
  public bool isPlayerAlive = true;
  private int seconds = 0;
  private float counter = 0;
  
  void Start()
  {
        
  }

  void Update()
  {
    if (seconds < 99 && isPlayerAlive)
    {
      counter += Time.deltaTime;
      seconds = (int)counter;

      timeLabel.text = seconds.ToString();
    }
  }
}
