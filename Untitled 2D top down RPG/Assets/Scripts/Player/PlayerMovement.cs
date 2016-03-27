using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

  public float speed;
  public float diagonalDrag;
  public Animator movAnim;
  public float saberDirection;

  void Start () {
  	movAnim = GetComponent<Animator>();
  }

  void FixedUpdate() {
  	float xMov = Input.GetAxisRaw("Horizontal");
  	float yMov = Input.GetAxisRaw("Vertical");
  	movAnim.SetFloat("velocity", Mathf.Abs(xMov) + Mathf.Abs(yMov));
  	if (Mathf.Abs(xMov) > 0 && Mathf.Abs(yMov) > 0 && Mathf.Abs(xMov) == Mathf.Abs(yMov)) {
  	  xMov = xMov / diagonalDrag;
  	  yMov = yMov / diagonalDrag;
  	}

    int dir = 0;
    if (yMov < 0 && Mathf.Abs(xMov) < Mathf.Abs(yMov))
      dir = 0; // Down
    else if (yMov > 0 && Mathf.Abs(xMov) < Mathf.Abs(yMov))
      dir = 1; // Up
    else if (xMov > 0)
      dir = 3; // Right
    else if (xMov < 0) 
      dir = 2; // Left
    movAnim.SetInteger("direction", dir);

    float newX = transform.position.x + (xMov * speed);
    float newY = transform.position.y + (yMov * speed);
    transform.position = new Vector3(newX,newY,transform.position.z);
  }

}
