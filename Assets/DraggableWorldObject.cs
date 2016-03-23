using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class DraggableWorldObject : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

	private Vector3 screenPoint;
	private Vector3 offset;

//	void OnMouseDown(){
//		screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
//		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
//	}
//		
//	void OnMouseDrag(){
//		Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
//		Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
//		transform.position = cursorPosition;
//	}

	#region IBeginDragHandler implementation
	public void OnBeginDrag (PointerEventData eventData)
	{
		screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(eventData.position.x, eventData.position.y, screenPoint.z));


	}
	#endregion

	#region IDragHandler implementation

	public void OnDrag (PointerEventData eventData)
	{
		Vector3 cursorPoint = new Vector3(eventData.position.x, eventData.position.y, screenPoint.z);
		Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
		transform.position = cursorPosition;

	}

	#endregion

	#region IEndDragHandler implementation

	public void OnEndDrag (PointerEventData eventData)
	{
	
	}

	#endregion

	float defHeight = 0f;

	bool itsMe = false;

	void Start () {
		defHeight = transform.position.y;
	}
	
	void Update () {
	
	}

	void GetUIElement () {
	
	
	}
}
