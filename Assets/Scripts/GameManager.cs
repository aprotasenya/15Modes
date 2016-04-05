using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	string[,] fieldMap;
	public Vector2 fieldSize;
	public Transform tileParent;
	public Transform defUICanvas;
	public GameObject tilePrefab;
	public GameObject tileLabelPrefab;
	public Vector3 tileSize;
	public Vector3 tileGap;

	void Start () {
	
		if (tileParent == null) {
			tileParent = GameObject.FindGameObjectWithTag ("TilesParent").transform;
		}

		if (tileSize == new Vector3 (0f, 0f, 0f)) {
			tileSize = new Vector3 (5f, 1f, 5f);
		}

		if (tileGap == new Vector3 (0f, 0f, 0f)) {
			tileGap = new Vector3 (tileSize.x * 0.1f, 0f, tileSize.z * 0.5f);
		}

	//	FillTheMap ();

	}
	


	public void FillTheMapRnd () {
	
		List<int> sizes = new List<int> ();
		sizes.AddRange (new int[] { 2, 3, 3, 4, 4 } );

		string log = ProBro.ArrayToString<int> (sizes.ToArray ());
		Debug.Log ("sizes = " + log);

		int rnX = Random.Range (0, sizes.Count);
		fieldSize.x = sizes [rnX];
		sizes.RemoveAt (rnX);

		log = ProBro.ArrayToString<int> (sizes.ToArray ());
		Debug.Log ("sizes = " + log);

		int rnY = Random.Range (0, sizes.Count);
		fieldSize.y = sizes [rnY];
		sizes.RemoveAt (rnY);

		log = ProBro.ArrayToString<int> (sizes.ToArray ());
		Debug.Log ("sizes = " + log);

		FillTheMap ();

	}

	public void FillTheMap () {

		fieldMap = new string [Mathf.RoundToInt (fieldSize.y), Mathf.RoundToInt (fieldSize.x)];
		Debug.Log ("map is " + fieldMap.GetLength (0).ToString () + "x" + fieldMap.GetLength (1).ToString ());

		List<int> nums = new List<int> ();
		for (int i = 1; i < Mathf.RoundToInt (fieldSize.x * fieldSize.y); i++) {
			nums.Add (i);
		}
		string log = ProBro.ArrayToString<int> (nums.ToArray ());
		Debug.Log ("nums: " + log + "; " + nums.Count + " items");

		for (int x = 0; x < fieldMap.GetLength (0); x++) {
			for (int y = 0; y < fieldMap.GetLength (1); y++) {

				if (nums.Count > 0) {
					int rnd = Random.Range (0, nums.Count - 1);
					fieldMap [x, y] = nums [rnd].ToString ();
					nums.RemoveAt (rnd);

				} else {
					fieldMap [x, y] = 0.ToString ();
					
				}

			}
		}

		Debug.Log ("Map ready");

		log = ProBro.ArrayToString<int> (nums.ToArray ());
		Debug.Log ("nums: " + log + "; " + nums.Count + " items");

	}


	public void LogFieldMap () {

		string log = ProBro.ArrayToString (fieldMap); 
		Debug.Log (log);
	
	}

	public void BuildTheField () {

		float tsX = tileSize.x;
		float tsY = tileSize.y;
		float tsZ = tileSize.z;
		float gapX = tileGap.x;
		float gapZ = tileGap.z;

		float oriX = ( (tsX * fieldMap.GetLength (1)) + (gapX * (fieldMap.GetLength (1) - 1f) ) ) * -0.5f;
		float oriY = 0f;
		float oriZ = ( (tsZ * fieldMap.GetLength (0)) + (gapZ * (fieldMap.GetLength (0) - 1f) ) ) * 0.5f;
		Vector3 originPoint = new Vector3 (oriX, oriY, oriZ);
		Debug.Log ("origin = " + originPoint.ToString ());

		for (int ix = 0; ix < fieldMap.GetLength (1); ix++) {
			for (int iy = 0; iy < fieldMap.GetLength (0); iy++) {

				if (fieldMap[iy, ix] != "0") {
					
					GameObject tile = (GameObject)GameObject.Instantiate (tilePrefab);
					tile.transform.SetParent (tileParent);
					tile.name = fieldMap [iy, ix];
					tile.transform.localScale = new Vector3 (tsX, tsY, tsZ);

					GameObject tileLabel = (GameObject)GameObject.Instantiate (tileLabelPrefab);
					tileLabel.transform.SetParent (defUICanvas);
					tileLabel.name = tile.name + "_Label";
					tileLabel.GetComponent<Text> ().text = tile.name;
					tileLabel.GetComponent<FollowingUI> ().SetTarget (tile);

					float tilePosX = (tsX * (ix + 0.5f)) + (gapX * ix);
					float tilePosY = 0f;
					float tilePosZ = -1f * ( (tsZ * (iy + 0.5f)) + (gapZ * iy) );
					
					tile.transform.position = originPoint + new Vector3 (tilePosX, tilePosY, tilePosZ);

				}

			}
		}


	}




}
