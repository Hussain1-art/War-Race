using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapsCircle : MonoBehaviour {
	public float distanceMax = 75f;

	private GameObject player;
	// Use this for initialization
	void Start () {
		player = CarControlCS.Player;
	}
	
	// Update is called once per frame
	void Update () {
		
		float distance = Vector3.Distance (new Vector3 (player.transform.position.x, 0, player.transform.position.z), new Vector3 (transform.position.x, 0, transform.position.z));

		if (distance > distanceMax) {
			
			Vector3 v = ((transform.position - player.transform.position) / distance * distanceMax) + player.transform.position;
			transform.position = new Vector3(v.x,Maps.maps.transform.position.y - 12,v.z);

		} else {
			
			transform.localPosition = new Vector3 (0,Maps.maps.transform.position.y - 12,0);

		}

	}
}
