using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
  public Text scoreLabel;
  public Animator playerAnimator;
  public Rigidbody playerRigidBody;
  public LayerMask groundLayer;
  public Timer timer;

  [Header("Sounds")]
  public AudioSource jumpAudioSource;
  public AudioSource crystalCollisionAudioSource;
  public AudioSource obstacleCollisionAudioSource;
  public AudioSource bgMusic;

  private static float FORWARD_SPEED = 5f;
  private static float SIDE_SPEED = 20f;
  private static float LEFT_BOUNDARY = -5f;
  private static float RIGHT_BOUNDARY = 5f;
  private static float JUMP_FORCE = 500f;

  private bool alive = true;
  private bool inGround = true;

  private int currentScore = 0;

  // Start is called before the first frame update
  void Start()
  {
        
  }

  // Update is called once per frame
  void Update()
  {
    if (alive)
    {
      inGround = Physics.CheckSphere(transform.position, 0.5f, groundLayer);

      float hInput = Input.GetAxis("Horizontal");
      float xTranslation = 0;
      float xCurrentPosition = transform.position.x;

      if ((hInput < 0 && xCurrentPosition > LEFT_BOUNDARY) || (hInput > 0 && xCurrentPosition < RIGHT_BOUNDARY))
      {
        xTranslation = SIDE_SPEED * Time.deltaTime * hInput;
      }
      else
      {
        xTranslation = 0;
      }

      transform.Translate(xTranslation, 0, FORWARD_SPEED * Time.deltaTime);

      if (Input.GetKeyDown(KeyCode.Space) && inGround)
      {
        Jump();
      }
    }
  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.tag.Equals("Obstacle"))
    {
      bgMusic.Stop();
      obstacleCollisionAudioSource.Play();
      alive = false;
      playerAnimator.SetBool("playerAlive", alive);
      timer.isPlayerAlive = false;
      Invoke("RestartLevel", 3);
    } else if (other.tag.Equals("Crystal")) 
    {
      crystalCollisionAudioSource.Play();
      Destroy(other.gameObject);
      currentScore++;
      scoreLabel.text = currentScore.ToString();
    }
  }

  private void RestartLevel()
  {
    SceneManager.LoadScene("Platform");
  }

  private void Jump()
  {
    playerRigidBody.AddForce(transform.up * JUMP_FORCE);
    jumpAudioSource.Play();
  }
}
