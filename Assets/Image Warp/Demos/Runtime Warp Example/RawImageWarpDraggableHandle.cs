using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Fenderrio.ImageWarp;
using UnityEngine.UI;

public class RawImageWarpDraggableHandle : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{


    public Color defaultColor;
    public Color ActiveColor;
    public Color SelectColor;
    public bool isActivate;

	public ImageWarpHandleType m_handleToAffect;

	[SerializeField]
	private RawImageWarp m_imageWarp;
    [SerializeField]
    private Image _image;

    public RawImageWarpDraggableHandle next;
    public RawImageWarpDraggableHandle pervious;

    public void OnBeginDrag(PointerEventData eventData)
	{
		SetDraggedPosition(eventData);
	}

	public void OnDrag(PointerEventData data)
	{
		SetDraggedPosition(data);
	}

	public void OnEndDrag(PointerEventData data)
	{
		SetDraggedPosition(data);
	}

	public System.Action<ImageWarpHandleType, Vector3> OnDragPositionEvent = null;

	private void SetDraggedPosition(PointerEventData data)
	{
		if (data.pointerEnter != null && data.pointerEnter.transform as RectTransform != null)
		{
			RectTransform m_DraggingPlane = data.pointerEnter.transform as RectTransform;

			Vector3 globalMousePos = Vector3.zero;
			if (RectTransformUtility.ScreenPointToWorldPointInRectangle (m_DraggingPlane, data.position, data.pressEventCamera, out globalMousePos))
			{
				transform.position = globalMousePos;

				if (OnDragPositionEvent != null)
				{
					OnDragPositionEvent ( m_handleToAffect, globalMousePos );
				}

				if (m_imageWarp != null)
				{
					m_imageWarp.SetHandleWorldPosition (m_handleToAffect, globalMousePos);
				}
			}
		}
	}





    public void Update()
    {
        if (isActivate)
        {

            if (Input.GetKey(KeyCode.W))
            {
              float newyPOS =    this.transform.position.y+ 0.001f;
                this.transform.position = new Vector3(this.transform.position.x, newyPOS, this.transform.position.z);
            }
            if (Input.GetKey(KeyCode.S))
            {
                float newyPOS = this.transform.position.y - 0.001f;
                this.transform.position = new Vector3(this.transform.position.x, newyPOS, this.transform.position.z);
            }

            if (Input.GetKey(KeyCode.D))
            {
                float newyPOS = this.transform.position.x + 0.001f;
                this.transform.position = new Vector3(newyPOS, this.transform.position.y, this.transform.position.z);
            }
            if (Input.GetKey(KeyCode.A))
            {
                float newyPOS = this.transform.position.x - 0.001f;
                this.transform.position = new Vector3(newyPOS, this.transform.position.y, this.transform.position.z);
            }


            m_imageWarp.SetHandleWorldPosition (m_handleToAffect, this.transform.position);
        }
    }

    public void setActive()
    {
        _image.color = ActiveColor;

        isActivate = true;
    }

    public void setDeActive()
    {
        _image.color = defaultColor;
        isActivate = false;
    }

    public void setSelect()
    {
        _image.color = SelectColor;
    }


    public void setdefaultColor()
    {
        _image.color = defaultColor;
    }


    private void OnValidate()
	{
		m_imageWarp = GetComponentInParent<RawImageWarp> ();

		if (m_imageWarp != null)
		{
			transform.position = m_imageWarp.GetHandleWorldPosition (m_handleToAffect);
		}

        _image = this.GetComponent<Image>();

    }
}
