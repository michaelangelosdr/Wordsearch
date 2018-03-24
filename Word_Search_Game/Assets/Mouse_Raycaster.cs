using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Mouse_Raycaster : MonoBehaviour, IPointerDownHandler {

	Ray ray;
	// Use this for initialization
	void Start () {
		ray = Camera.main.ScreenPointToRay (Input.mousePosition);
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void OnPointerDown(PointerEventData eventData)
	{
		Debug.Log ("Clicked: " + gameObject.name);
	}
}
