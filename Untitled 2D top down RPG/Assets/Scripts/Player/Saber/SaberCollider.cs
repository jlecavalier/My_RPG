using UnityEngine;
using System.Collections;

public class SaberCollider : MonoBehaviour {

  public float enemyDeathSpeed;
  
  public void OnCollisionEnter2D(Collision2D other) {
  	if (other.gameObject.tag == "Enemy") {
  	  float x = other.contacts[0].point.x;
  	  float y = other.contacts[0].point.y;
  	  Vector2 dir = new Vector2(x, y);
  	  dir = dir.normalized * enemyDeathSpeed;
  	  other.rigidbody.AddForce(dir);
  	}
  }
}
