using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public enum ItemType {NONE, GREEN, PURPLE};

public class Selector : MonoBehaviour {

  private GameObject[] slots;
  
  // This is called when the user activates an inventory slot
  public void SlotActivated(GameObject currSlot) {
    
    // Get the list of all the slots
    slots = GameObject.FindGameObjectsWithTag("EquipmentSlot");
    
    // Get the sprites from the activated slot
    Sprite theSprite = currSlot.GetComponent<Image>().sprite;
    SpriteState theSpriteState = currSlot.GetComponent<Button>().spriteState;
    ItemType theType = currSlot.GetComponent<ItemEnum>().type;
 
    // Z is for slot zero, X is for slot 1
  	if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.JoystickButton2)) {
      // Swap the Z slot and the selected slot.
      currSlot.GetComponent<Image>().sprite = slots[0].GetComponent<Image>().sprite;
      currSlot.GetComponent<Button>().spriteState = slots[0].GetComponent<Button>().spriteState;
      currSlot.GetComponent<ItemEnum>().type = slots[0].GetComponent<ItemEnum>().type;
      slots[0].GetComponent<Image>().sprite = theSprite;
      slots[0].GetComponent<Button>().spriteState = theSpriteState;
      slots[0].GetComponent<ItemEnum>().type = theType;
    }
    else if (Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.JoystickButton0)) {
      // Swap the X slot and the selected slot.
      currSlot.GetComponent<Image>().sprite = slots[1].GetComponent<Image>().sprite;
      currSlot.GetComponent<Button>().spriteState = slots[1].GetComponent<Button>().spriteState;
      currSlot.GetComponent<ItemEnum>().type = slots[1].GetComponent<ItemEnum>().type;
      slots[1].GetComponent<Image>().sprite = theSprite;
      slots[1].GetComponent<Button>().spriteState = theSpriteState;
      slots[1].GetComponent<ItemEnum>().type = theType;
    }
    else if (Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.JoystickButton1)) {
      // Swap the C slot and the selected slot.
      currSlot.GetComponent<Image>().sprite = slots[2].GetComponent<Image>().sprite;
      currSlot.GetComponent<Button>().spriteState = slots[2].GetComponent<Button>().spriteState;
      currSlot.GetComponent<ItemEnum>().type = slots[2].GetComponent<ItemEnum>().type;
      slots[2].GetComponent<Image>().sprite = theSprite;
      slots[2].GetComponent<Button>().spriteState = theSpriteState;
      slots[2].GetComponent<ItemEnum>().type = theType;
    }
  }
}
