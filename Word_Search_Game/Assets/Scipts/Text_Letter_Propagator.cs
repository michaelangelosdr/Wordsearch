using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text_Letter_Propagator : MonoBehaviour {

	[SerializeField] GameObject Text_Prefab;
	List<GameObject> Grid_Board_Members;
	private GameObject[,] Grid_Board;
	public int Board_Size;
	string c_Letter = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";



	// Use this for initialization
	void Start () {
		Grid_Board = new GameObject[Board_Size, Board_Size];

		Initialize_Letters();

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.R)) {
			Re_Randomize_Letter ();
		}

		if (Input.GetKeyDown (KeyCode.A)) {
			InsertWord_In_Gridboard ("dog", 1);
		}
		if (Input.GetKeyDown (KeyCode.S)) {
			InsertWord_In_Gridboard ("dog", 0);
		}


	}

	public void Initialize_Letters()
	{
		for (int Row = 0; Row < Board_Size; Row++) {
			for (int column = 0; column < Board_Size; column++) {

				GameObject LetterItem = Instantiate (Text_Prefab, new Vector3 (column + -2.5f, Row + 2, 1), Quaternion.identity) as GameObject;
				LetterItem.name = "Row: " + Row.ToString () + " Column: " + column.ToString ();
				LetterItem.GetComponent<TextMesh> ().text = c_Letter[Random.Range(0,26)].ToString();
				LetterItem.transform.SetParent (this.transform);
				Grid_Board [column, Row] = LetterItem;
			}
		}
	}

	public void Re_Randomize_Letter()
	{for (int Row = 0; Row < Board_Size; Row++) {
			for (int column = 0; column < Board_Size; column++) {
				Grid_Board[Row,column].GetComponent<TextMesh> ().text = c_Letter[Random.Range(0,26)].ToString();
			}				
		}

	}



	//Spot = 1col or 0row
	public void InsertWord_In_Gridboard(string word, int spot)
	{
		if (word.Length > Board_Size) {
			Debug.LogError (" Word bigger than board ");
			return;
		}

		if (spot == 0) {
			// Row
			int column = Random.Range(0,Board_Size);
			int row = Random.Range (0, Board_Size - (word.Length-1));

			Debug.Log ("Insert word at : Row:" + column + " Col: " + row);

			for (; row < Board_Size-1;)
			{
				for (int word_index_size = 0; word_index_size < word.Length; word_index_size++) {
					if (Grid_Board [row, column].GetComponent<TextMesh> ().text == word [word_index_size].ToString ()) {
						row++;
					} else {
						Grid_Board [row, column].GetComponent<TextMesh> ().text = word [word_index_size].ToString ();
						row++;
					}
				}

			}


		} else if (spot == 1) {

			int column = Random.Range(0,Board_Size - (word.Length-1));
			int row = Random.Range (0, Board_Size);

			Debug.Log ("Insert word at : Row:" + column + " Col: " + row);

			for (; column < Board_Size-1; )
			{
				for (int word_index_size = word.Length - 1; word_index_size >= 0; word_index_size--) {
					if (Grid_Board [row, column].GetComponent<TextMesh> ().text == word [word_index_size].ToString ()) {
						column++;
					} else {
						Grid_Board [row, column].GetComponent<TextMesh> ().text = word [word_index_size].ToString ();
						column++;Do
					}
				}
			}


		}


	}

}
