using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour {
	public float openType; //Определяет с какой стороны открывается дверь(двеврь всегда открывается от себя)

	public bool openFlag; //Комманда на открытие двери
	public bool openedFlag; //Открыта ли дверь

	public float time = 0; 

	public Quaternion start;
	public Quaternion finish;
	
	void Start () {
		start = transform.rotation;
	}
	
	
	void Update () {

		if(openFlag)
		{
			time += Time.deltaTime;
			
			transform.rotation = Quaternion.Lerp(start, finish, Time.deltaTime);
			openedFlag = !openedFlag;
			if(time > 1) openFlag = false;
		}
	}

	public void Open()
	{
			if(!openedFlag)
			finish = new Quaternion(start.x, start.y-90, start.z, start.w);
			else
			finish = new Quaternion(start.x, start.y, start.z, start.w);
			openFlag = true;
			time = 0;
	}


}
