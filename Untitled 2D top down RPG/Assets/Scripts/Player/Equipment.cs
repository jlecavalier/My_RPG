using UnityEngine;
using System.Collections;

public class Equipment : MonoBehaviour {

  public ItemType zSlot;
  public ItemType xSlot;
  public ItemType cSlot;
  public bool saberAttack;

  private Animator movAnim;

  public void UpdateEquipment() {
  	GameObject[] slots = GameObject.FindGameObjectsWithTag("EquipmentSlot");

  	zSlot = slots[0].GetComponent<ItemEnum>().type;
  	xSlot = slots[1].GetComponent<ItemEnum>().type;
  	cSlot = slots[2].GetComponent<ItemEnum>().type;
  }

  private void DoItem (ItemType type) {
  	switch (type) {
  	  case ItemType.NONE:
  	  	break;
  	  case ItemType.GREEN:
  	  	saberAttack = true;
  	  	//yield return new WaitForSeconds(.09f);
  	  	break;
  	  case ItemType.PURPLE:
  	  	break;
  	}
  }

  public void Update () {
    CheckKeys();
  	movAnim.SetBool("saberAttack", saberAttack);
  }

  private void CheckKeys () {
    if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.JoystickButton2)) {
      DoItem(zSlot);
    }
    else if (Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.JoystickButton0)) {
      DoItem(xSlot);
    }
    else if (Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.JoystickButton1)) {
      DoItem(cSlot);
    }
  }

  public void Start () {
  	movAnim = GetComponent<Animator>();
  }

}