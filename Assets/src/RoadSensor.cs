using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSensor : MonoBehaviour
{
  private RoadManager roadManager;

  private void Awake()
  {
    roadManager = FindObjectOfType<RoadManager>();
  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.tag.Equals("Player"))
    {
      int moduleIndex = Random.Range(0, 4);
      Vector3 modulePosition = new Vector3(0, 0, transform.parent.transform.position.z + 80);
      GameObject module = roadManager.modules[moduleIndex];
      Instantiate(module, modulePosition, transform.rotation);
    }
  }
}
