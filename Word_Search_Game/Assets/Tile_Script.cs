using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tile_Script : MonoBehaviour {

	//
	Tile_States tile_state;
	[SerializeField] Image Tile_BG_Image;

	[SerializeField] GameObject Tile_BG_Image_Idle;
	[SerializeField] GameObject Tile_BG_Image_Selected;
	[SerializeField] Text Tile_Text;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
		if (tile_state == Tile_States.Idle_State) {
			set_this_Tile_to (Tile_BG_Image_Idle);
		} else if (tile_state == Tile_States.Selected_State) {
			set_this_Tile_to (Tile_BG_Image_Selected);
		}

	}

	public void set_this_Tile_to(GameObject setobject)
	{
		Tile_BG_Image_Idle.SetActive (false);
		Tile_BG_Image_Selected.SetActive (false);
		setobject.SetActive (true);

	}

	public void Selected()
	{
		tile_state = Tile_States.Selected_State;
	}
	public void Unselected()
	{
		tile_state = Tile_States.Idle_State;
	}

}
public enum Tile_States
{
	Idle_State,
	Selected_State,
	Completed_State
}
