using UnityEngine;
using System.Collections;

public class EnemyCollisions : MonoBehaviour {

  public bool alive;
  public GameObject saber;
  public GameObject player;

  private Animator enemyAnim;

  void Start () {
    enemyAnim = GetComponent<Animator>();

    saber = GameObject.FindWithTag("Saber");
    player = GameObject.FindWithTag("Player");
  }
  
  void OnTriggerEnter2D(Collider2D other) {
    if (other.gameObject == saber) {
      enemyAnim.SetBool("die", true);
    }
  }

  void Update () {
    if (!alive) {
      gameObject.SetActive(false);
    }
  }

}
