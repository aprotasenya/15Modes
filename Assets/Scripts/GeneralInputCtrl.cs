using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GeneralInputCtrl : MonoBehaviour {

	public KeyCode reloadSceneKey = KeyCode.R;
	public KeyCode fillMapKey = KeyCode.F;
	public KeyCode debugMapKey = KeyCode.D;
	public KeyCode buildFieldKey = KeyCode.B;

	GameManager mngr;

	void Start () {
		mngr = gameObject.GetComponent<GameManager> ();

	}
	

	void Update () {
	
		if (Input.GetKeyUp (reloadSceneKey))
			ReloadScene ();

		if (Input.GetKeyUp (fillMapKey))
			mngr.FillTheMap ();

		if (Input.GetKeyUp (debugMapKey))
			mngr.LogFieldMap ();

		if (Input.GetKeyUp (buildFieldKey))
			mngr.BuildTheField ();

	}

	public void ReloadScene () {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);

	}
}
