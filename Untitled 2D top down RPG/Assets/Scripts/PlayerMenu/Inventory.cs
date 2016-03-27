using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

  private RectTransform inventoryRect;
  private float inventoryWidth, inventoryHeight;
  private List<GameObject> slots;
  private int selectedNumber;
  private EventSystem invEvents;

  public int numSlots, numRows;
  public float slotPaddingLeft, slotPaddingTop;
  public float slotSize;
  public float borderPadding;
  public GameObject slotPrefab;
  public GameObject equipment;
  public GameObject player;
  public bool isReady;

  public Sprite grnNormal;
  public Sprite grnHighlight;
  public Sprite grnPressed;
  public Sprite prpNormal;
  public Sprite prpHighlight;
  public Sprite prpPressed;

  // Sets the size of the inventory background
  private void CreateBackground() {
  	// Get the width and height of the inventory
  	inventoryWidth = (numSlots / numRows) * (slotSize + slotPaddingLeft) + slotPaddingLeft + borderPadding;
  	inventoryHeight = numRows * (slotSize + slotPaddingTop) + slotPaddingTop + borderPadding;
  	// Reference to the RectTransform of our inventory
  	inventoryRect = GetComponent<RectTransform>();
  	// Set the width and height of the inventory accordingly
  	inventoryRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, inventoryWidth);
  	inventoryRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, inventoryHeight);
  }

  // calculate the position of each slot within the background
  private void CreateSlots() {
  	// A list of slots for easy access.
  	slots = new List<GameObject>();
  	// Get the number of columns
  	int numColumns = numSlots / numRows;
  	// iterate through each row and column
  	for (int y = 0; y < numRows; y++) {
  	  for (int x = 0; x < numColumns; x++) {
  	  	// Create the new slot
  	  	GameObject newSlot = (GameObject)Instantiate(slotPrefab);
  	  	// Reference to the RectTransform of the new slot
  	  	RectTransform slotRect = newSlot.GetComponent<RectTransform>();
  	  	// Name the slot appropriately
  	  	newSlot.name = "Slot";
  	  	// Set the parent of the new slot to the parent of the inventory (i.e. the canvas)
  	  	newSlot.transform.SetParent(this.transform.parent);
  	  	// Calculate the position for the slot
  	  	float newX = slotPaddingLeft * (x + 1) + (slotSize * x) + borderPadding;
  	  	float newY = -slotPaddingTop * (y + 1) - (slotSize * y) - borderPadding;
  	  	slotRect.localPosition = inventoryRect.localPosition + new Vector3(newX, newY);
  	  	// Resize the slot appropriately
  	  	slotRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, slotSize);
  	  	slotRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, slotSize);
  	  	// Add the new slot to the list of slots
  	  	slots.Add(newSlot);
  	  }
  	}
  	invEvents.SetSelectedGameObject(slots[0]);
  }

  private void CreateItems() {
    SpriteState grnSt = new SpriteState();
    grnSt.highlightedSprite = grnHighlight;
    grnSt.pressedSprite = grnPressed;
    slots[3].GetComponent<Image>().sprite = grnNormal;
    slots[3].GetComponent<Button>().spriteState = grnSt;
    slots[3].GetComponent<ItemEnum>().type = ItemType.GREEN;

    SpriteState prpSt = new SpriteState();
    prpSt.highlightedSprite = prpHighlight;
    prpSt.pressedSprite = prpPressed;
    slots[5].GetComponent<Image>().sprite = prpNormal;
    slots[5].GetComponent<Button>().spriteState = prpSt;
    slots[5].GetComponent<ItemEnum>().type = ItemType.PURPLE;
  }

  private bool predicate (GameObject s) {
    return invEvents.currentSelectedGameObject == s;
  }
  
  public void StoreSelection () {
    selectedNumber = slots.FindIndex(predicate);
  }

  public void LoadSelection () {
    if (slots != null) {
      invEvents.SetSelectedGameObject(slots[selectedNumber]);
    }       
  }

  // Set up the inventory
  public void Start () {
    selectedNumber = 0;
    invEvents = GameObject.FindWithTag("InvEvents").GetComponent<EventSystem>();
  	CreateBackground();
  	CreateSlots();
    CreateItems();
    EquipmentCreator equipmentCreator = equipment.GetComponent<EquipmentCreator>();
    equipmentCreator.CreateBackground();
    isReady = true;
  }
}
