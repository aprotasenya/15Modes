using UnityEngine;
using System.Collections;

public class FollowingUI : MonoBehaviour {

	public GameObject trgt;
	Vector3 lastTargetPos;
	RectTransform rectTransform;

	void Awake () {

		rectTransform = this.GetComponent<RectTransform> ();
	
	}
	
	void Update () {

		if (trgt == null)
			return;
		
		if (trgt.transform.position != lastTargetPos) {
			Align ();
		}
	
	}

	public void SetTarget (GameObject target) {

		trgt = target;
		Align ();
	
	}

	public void Align () {
	
		lastTargetPos = trgt.transform.position;
		rectTransform.position = Camera.main.WorldToScreenPoint (trgt.transform.position);
	
	}

}
