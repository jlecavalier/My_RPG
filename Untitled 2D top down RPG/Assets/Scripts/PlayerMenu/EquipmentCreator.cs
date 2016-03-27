using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class EquipmentCreator : MonoBehaviour {
  
  public GameObject inventory;
  public Canvas canvas;
  public GameObject slotPrefab;
  
  private RectTransform equipmentRect;
  private float equipmentWidth, equipmentHeight;
  private float slotSize;
  private List<GameObject> slots;

  public void CreateBackground() {
  	// Get the width and height of the equipment
  	equipmentRect = GetComponent<RectTransform>();
  	RectTransform inventoryRect = inventory.GetComponent<RectTransform>();
  	equipmentWidth = inventoryRect.rect.width * canvas.scaleFactor;
  	slotSize = (equipmentWidth - 5) / 4;
  	equipmentHeight = slotSize + 15;
  	equipmentRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, equipmentWidth);
    equipmentRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, equipmentHeight);
    CreateSlots();
  }

  public void CreateSlots() {
  	slots = new List<GameObject>();

  	for  (int i = 0; i < 3; i++) {
  	  GameObject newSlot = (GameObject)Instantiate(slotPrefab);
  	  RectTransform slotRect = newSlot.GetComponent<RectTransform>();
  	  newSlot.name = "Slot";
  	  newSlot.tag = "EquipmentSlot";
  	  newSlot.transform.SetParent(this.transform.parent);
  	  float newX = (slotSize * i) + (slotSize / 2);
  	  float newY = -7;
  	  newSlot.GetComponent<Button>().interactable = false;
  	  slotRect.localPosition = equipmentRect.localPosition + new Vector3(newX, newY);
  	  slotRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal,slotSize);
  	  slotRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical,slotSize);
  	  slots.Add(newSlot);
  	}
  }
}
