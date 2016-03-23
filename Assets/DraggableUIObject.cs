using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class DraggableUIObject : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

	#region IBeginDragHandler implementation
	public void OnBeginDrag (PointerEventData eventData)
	{
		
	}
	#endregion

	#region IDragHandler implementation

	public void OnDrag (PointerEventData eventData)
	{


	}

	#endregion

	#region IEndDragHandler implementation

	public void OnEndDrag (PointerEventData eventData)
	{


	}

	#endregion


	void Start () {
	
	}
	
	void Update () {
	
	}
		
}
