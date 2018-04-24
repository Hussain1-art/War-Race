using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maps : MonoBehaviour {
	public static GameObject maps;
	// Use this for initialization
	void Start () {
		maps = gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (CarControlCS.Player.transform.position.x, transform.position.y,CarControlCS.Player.transform.position.z);
	}
}
