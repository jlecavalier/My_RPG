using UnityEngine;
using System.Collections;

public class PlayerCollisions : MonoBehaviour {
  void OnTriggerEnter2D(Collider2D other) {
  	if (other.gameObject.tag == "Enemy") {
  	  Debug.Log("enemy collision");
  	}
  }
}
