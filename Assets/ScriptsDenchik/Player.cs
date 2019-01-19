using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public Transform LighterHolder;
	public Transform Lighter;
	public Transform RaySpawn;

	//Flags
	public bool seesItem;

	//Resources
	public Texture seesItemT;

	//GUI stuff
	public Rect seesItemRect;
	
	void Start () {
		seesItemRect = new Rect(Screen.width/2, Screen.height/2, 32, 32);
	}
	
	// Update is called once per frame
	void Update () {
		//Поднятие предметов
		RaycastHit hit;
		if(Physics.Raycast(RaySpawn.position, RaySpawn.forward, out hit, 5))
		{
			
			if(hit.transform.tag == "Item") //Если игрок смотрит на предмет
			{
				seesItem = true;
				if(hit.transform.name == "Lighter" && Input.GetKeyDown(KeyCode.E))
				{
					Lighter = hit.transform;
					Lighter.parent = LighterHolder;
					Lighter.position = LighterHolder.position;
					Lighter.GetComponent<BoxCollider>().enabled = false;
					Lighter.rotation = LighterHolder.rotation;
				}
			}
			else if(hit.transform.tag == "Door")
			{
				seesItem = true;
				if(Input.GetKeyDown(KeyCode.E))
				{
					
					if(hit.transform.GetComponent<DoorScript>())
					hit.transform.GetComponent<DoorScript>().Open();
				}
			}
			else //Если игрок смотрит на объект, на не на предмет, с которым можно взаимодействовать
			{
				seesItem = false;
			}
		}
		else //Если игрок ни на что не смотрит
		{
			seesItem = false;
		}

		//Обработка ввода
		if (Input.GetKeyDown(KeyCode.R))
		{
			if(Lighter!=null)
			if(Lighter.GetComponent<Lighter>().fuel > 0)
			{
				Lighter.Find("FlameLight").GetComponent<Light>().enabled = !Lighter.Find("FlameLight").GetComponent<Light>().enabled;
			}
		}
		
	}

	void OnGUI()
	{
		if(seesItem)
		{
			GUI.DrawTexture(seesItemRect, seesItemT);
		}
	}
}
