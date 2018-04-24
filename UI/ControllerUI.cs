using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerUI : MonoBehaviour {

	public Text speed;
	// Use this for initialization
	void Start () {
		speed.text = (CarControlCS.Player != null)? CarControlCS.Player.GetComponent<CarControlCS>().getCurrentSpeed ().ToString() + " MPH" : "000 MPH";
	}
	
	// Update is called once per frame
	void Update () {
		speed.text = (CarControlCS.Player != null)? CarControlCS.Player.GetComponent<CarControlCS>().getCurrentSpeed ().ToString() + " MPH" : "000 MPH";
	}

	public void Repair (){
		CarControlCS.Player.GetComponent<CarControlCS> ().RepairCar ();
	}

}
