using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadDestroyer : MonoBehaviour
{
  private void OnTriggerEnter(Collider other)
  {
    if (other.tag.Equals("WallSensor"))
    {
      Destroy(other.transform.parent.gameObject);
    }
  }
}
