using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighter : MonoBehaviour {
	public Light lightS;
	[Range(0,300)]
	public float fuel; 

	public Texture fuelT;

	public Rect fuelR;
	
	void Start () {
		fuel = Random.Range(30,300);
		fuelR = new Rect(10,10,fuel,50);
	}
	
	
	void Update () {
		if(lightS.enabled)
		if(fuel > 0) fuel -= Time.deltaTime;
		else {lightS.enabled = false;}
		//Изменение интенсивности свечения в зависимости от оставшегося топлива
		lightS.intensity = fuel/60;
	}
//Отрисовка количества топлива
	void OnGUI()
	{//Отрисовка количества топлива, если зажигалка находится у игрока
	    if(transform.parent!=null)
		if(transform.parent.name == "LighterHolder")
		{
			GUI.DrawTexture(new Rect(10,10,fuel,10), fuelT);
		}
	}
}
