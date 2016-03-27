using UnityEngine;
using System.Collections;

public class GlobalControls : MonoBehaviour {

  private bool isPaused;
  private GameObject[] playerMenuObs;

  public GameObject inventory;
  public GameObject player;

  void Start () {
  	//Cursor.visible = false;
  	//Cursor.lockState = CursorLockMode.Locked;
  	isPaused = false;
  	playerMenuObs = GameObject.FindGameObjectsWithTag("PlayerMenu");
  	foreach(GameObject ob in playerMenuObs) {
  	  ob.gameObject.SetActive(false);
  	}
  }

  void Update () {
  	if (Input.GetKey("escape")) {
  	  Application.Quit();
  	}

  	if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.JoystickButton7)) {
  	  isPaused = !isPaused;
  	  if (isPaused) {
  	  	Time.timeScale = 0;
  	  	foreach(GameObject ob in playerMenuObs) {
  	  	  ob.gameObject.SetActive(true);
  	  	}
  	  	inventory.GetComponent<Inventory>().LoadSelection();
  	  }
  	  else {
  	  	inventory.GetComponent<Inventory>().StoreSelection();
  	  	Time.timeScale = 1;
        player.GetComponent<Equipment>().UpdateEquipment();
  	  	foreach(GameObject ob in playerMenuObs) {
  	  	  ob.gameObject.SetActive(false);
  	  	}
  	  }
  	}
  }
}
