using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleObstacle : MonoBehaviour
{
  private static int DEFAULT_ANGLE = 90;
  private static int MAX_AMOUNT_OF_STONES_PER_MODULE = 10;
  private RoadManager roadManager;
  public List<GameObject> obstacles;

  private void Awake()
  {
    roadManager = FindObjectOfType<RoadManager>();
  }

  private void Start()
  {
    int obstacleIndex = Random.Range(0, obstacles.Count + 1);
    int selectedRotation = Random.Range(0, 2);
    int rotationAngle = selectedRotation * DEFAULT_ANGLE;

    Quaternion euler = Quaternion.Euler(0, rotationAngle, 0);

    if (obstacleIndex < obstacles.Count)
    {
      GameObject obstacle = obstacles[obstacleIndex];
      GameObject newObstacle = Instantiate(obstacle, transform.position, euler);
      newObstacle.transform.parent = this.transform;
    }

    BuildStones(MAX_AMOUNT_OF_STONES_PER_MODULE);
  }

  private void BuildStones(int amount)
  {
    for (int index = 0; index < amount; index++)
    {
      BuildStone();
      BuildCrystal();
    }
  }

  private void BuildStone()
  {
    int posX = Random.Range(-9, 9);
    int posZ = Random.Range(-10, 10);
    int stoneIndex = Random.Range(0, roadManager.stones.Count);
    Vector3 newPosition = new Vector3(transform.position.x + posX, 0, transform.position.z + posZ);

    GameObject newStone = Instantiate(roadManager.stones[stoneIndex], newPosition, Quaternion.Euler(0, Random.Range(0, 360), 0));
    newStone.transform.parent = transform;
  }

  private void BuildCrystal()
  {
    int posX = Random.Range(-9, 9);
    int posZ = Random.Range(-10, 10);
    Vector3 newPosition = new Vector3(transform.position.x + posX, 0.5f, transform.position.z + posZ);

    GameObject newCrystal = Instantiate(roadManager.crystal, newPosition, Quaternion.Euler(0, Random.Range(0, 360), 0));
    newCrystal.transform.parent = transform;
  }
}
