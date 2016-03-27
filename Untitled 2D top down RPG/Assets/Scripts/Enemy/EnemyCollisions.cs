using UnityEngine;
using System.Collections;

public class EnemyCollisions : MonoBehaviour {

  public float deathSpeed;
  public bool alive;
  public GameObject saber;
  public GameObject player;

  private Rigidbody2D enemyRigidbody2D;
  private Animator enemyAnim;

  void Die (float dir) {
    switch ((int)dir) {
      case 0:
        enemyRigidbody2D.AddForce(Vector2.down * deathSpeed);
        enemyAnim.SetBool("die", true);
        break;
      case 1:
        enemyRigidbody2D.AddForce(Vector2.up * deathSpeed);
        enemyAnim.SetBool("die", true);
        break;
      case 2:
        enemyRigidbody2D.AddForce(Vector2.left * deathSpeed);
        enemyAnim.SetBool("die", true);
        break;
      case 3:
        enemyRigidbody2D.AddForce(Vector2.right * deathSpeed);
        enemyAnim.SetBool("die", true);
        break;
    }
  }

  void Start () {
    enemyRigidbody2D = GetComponent<Rigidbody2D>();
    enemyAnim = GetComponent<Animator>();

    saber = GameObject.FindWithTag("Saber");
    player = GameObject.FindWithTag("Player");
  }
  
  void OnTriggerEnter2D(Collider2D other) {
    if (other.gameObject == saber) {
      Die(player.GetComponent<PlayerMovement>().saberDirection);
    }
  }

  void Update () {
    if (!alive) {
      gameObject.SetActive(false);
    }
  }

}
