using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public Transform LighterHolder;
	public Transform Lighter;
	public Transform Camera;

	//Flags
	public bool seesItem;

	//Resources
	public Texture seesItemT;

	//GUI stuff
	public Rect seesItemRect;
	
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		if(Physics.Raycast(Camera.position, Vector3.forward, out hit, 5))
		{
			if(hit.transform.tag == "Item")
			{

			}
		}
		
	}

	void OnGUI()
	{
		if(seesItem)
		{
			GUI.DrawTexture()
		}
	}
}
