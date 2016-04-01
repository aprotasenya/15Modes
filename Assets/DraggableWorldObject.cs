using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using DG.Tweening;

public class DraggableWorldObject : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

	private Vector3 screenPoint;
	private Vector2 drag;
	private Vector3 offset;
	private bool readingDrag = false;
	public float dragMinLength = 5f;

	#region IBeginDragHandler implementation
	public void OnBeginDrag (PointerEventData eventData)
	{
		screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(eventData.position.x, eventData.position.y, screenPoint.z));
		drag = new Vector2 (0f, 0f);
		readingDrag = true;

	}
	#endregion

	#region IDragHandler implementation

	public void OnDrag (PointerEventData eventData)
	{
//		Vector3 cursorPoint = new Vector3(eventData.position.x, eventData.position.y, screenPoint.z);

		if (!readingDrag) return;

		drag += eventData.delta;
		Debug.Log (drag + "; m" + drag.magnitude);

		if ((drag.magnitude > dragMinLength) && (drag.x != drag.y)) {

			float xOne = (Mathf.Abs (drag.x) > Mathf.Abs (drag.y)) ? (1f * Mathf.Sign (drag.x)) : 0;
			float yOne = (Mathf.Abs (drag.y) > Mathf.Abs (drag.x)) ? (1f * Mathf.Sign (drag.y)) : 0;

			Vector2 dragOne = new Vector2 (xOne, yOne);
			Vector3 moveByV = new Vector3 (xOne, 0f, yOne) * 5.5f;
			Debug.Log ("one " + dragOne);

			readingDrag = false;
			transform.DOMove (moveByV, 0.1f).SetRelative ()
				.SetEase(Ease.Linear);
		}


//		Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
//		transform.position = cursorPosition;


	}

	#endregion

	#region IEndDragHandler implementation

	public void OnEndDrag (PointerEventData eventData)
	{
		readingDrag = false;
	}

	#endregion

}
