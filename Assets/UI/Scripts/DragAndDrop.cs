using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

using WPMF;


[RequireComponent(typeof(Image))]
public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
	public GameObject confirmPopup;

	private GameObject abilityBar;
	private RectTransform abilityBarTransfrom;
	private Vector2 prevPosition;

    public bool dragOnSurfaces = true;

    private Dictionary<int, GameObject> m_DraggingIcons = new Dictionary<int, GameObject>();
    private Dictionary<int, RectTransform> m_DraggingPlanes = new Dictionary<int, RectTransform>();
    private string objName = "";

	//MAX!
	public string ModName;

	private HoldToDisplay holdScript;
	WorldMap2D map;
	int previousIndex = -1;

	bool pointerDown = false;
	float pointerDownTimer = 0f;
	float holdThreshold = 0.5f;

	private void Start()
	{
		map = WorldMap2D.instance;
		holdScript = this.gameObject.GetComponent<HoldToDisplay> ();
		holdScript.setName (ModName);

		abilityBar = GameObject.Find ("AbilityBar");
		abilityBarTransfrom = abilityBar.GetComponent<RectTransform> ();
		prevPosition = new Vector2 (abilityBarTransfrom.anchoredPosition.x, abilityBarTransfrom.anchoredPosition.y);
	}



    public void OnBeginDrag(PointerEventData eventData)
    {
		//MAX!
		if (map.lockDrag) {
			map.isOnDrag = false;
			previousIndex = -1;
			return;
		}


		//hides the ability bar physically, also achievable through camera culling mask
		abilityBarTransfrom.anchoredPosition = new Vector2(0f,-300f);

		map.isOnDrag = true;

        var canvas = FindInParents<Canvas>(gameObject);
        if (canvas == null)
            return;

        m_DraggingIcons[eventData.pointerId] = new GameObject("icon");

        m_DraggingIcons[eventData.pointerId].transform.SetParent(canvas.transform, false);
        m_DraggingIcons[eventData.pointerId].transform.SetAsLastSibling();

        var image = m_DraggingIcons[eventData.pointerId].AddComponent<Image>();
        // The icon will be under the cursor. It is ignored by the event system.
        var group = m_DraggingIcons[eventData.pointerId].AddComponent<CanvasGroup>();
        group.blocksRaycasts = false;

        image.sprite = GetComponent<Image>().sprite;
		image.color = new Color (image.color.r, image.color.g, image.color.b, 0.5f);

        //Set the private variable objName to hold the name of the source icon
        objName = gameObject.transform.name;

        if (dragOnSurfaces)
            m_DraggingPlanes[eventData.pointerId] = transform as RectTransform;
        else
            m_DraggingPlanes[eventData.pointerId] = canvas.transform as RectTransform;

        SetDraggedPosition(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
		//MAX!
		holdScript.resetHold();

		if (map.lockDrag) {
			map.isOnDrag = false;
			previousIndex = -1;
			return;
		}


		if (m_DraggingIcons [eventData.pointerId] != null) {
			SetDraggedPosition (eventData);

			//MAX!
			if (map.cursorCountryIndex != -1 && map.cursorCountryIndex!= previousIndex) {
				previousIndex = map.cursorCountryIndex;
                if (map.countries[map.cursorCountryIndex].data.notEliminated)
                {
                    map.possibleCost = map.getCost(previousIndex, ModName);
                    if (map.Energy - map.possibleCost<0 || map.possibleCost < 0)
                    {
                        map.possibleCost = -1;
                    }
                }
                else
                {
                    map.possibleCost = 0;
                }
               
			}else if (map.cursorCountryIndex == -1)
            {
                map.possibleCost = 0;
            }


		}
    }

    private void SetDraggedPosition(PointerEventData eventData)
    {
        if (dragOnSurfaces && eventData.pointerEnter != null && eventData.pointerEnter.transform as RectTransform != null)
            m_DraggingPlanes[eventData.pointerId] = eventData.pointerEnter.transform as RectTransform;
        var rt = m_DraggingIcons[eventData.pointerId].GetComponent<RectTransform>();
        Vector3 globalMousePos;
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(m_DraggingPlanes[eventData.pointerId], eventData.position, eventData.pressEventCamera, out globalMousePos))
        {
            rt.position = globalMousePos;
            rt.rotation = m_DraggingPlanes[eventData.pointerId].rotation;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
		abilityBarTransfrom.anchoredPosition = prevPosition;


		if (map.tutorialMode) {

		} else {
			if (map.lockDrag) {
				map.isOnDrag = false;
				previousIndex = -1;
				return;
			}

			Debug.Log ("Parameter " + objName + " at " + eventData.position);
			if (m_DraggingIcons [eventData.pointerId] != null)
				Destroy (m_DraggingIcons [eventData.pointerId]);

			m_DraggingIcons [eventData.pointerId] = null;
			objName = "";

			//MAX!
			map.isOnDrag = false;
			previousIndex = -1;
			if (map.possibleCost != -1) {
				InstantiateMod ();
			}
		}

    }

    static public T FindInParents<T>(GameObject go) where T : Component
    {
        if (go == null) return null;
        var comp = go.GetComponent<T>();

        if (comp != null)
            return comp;

        var t = go.transform.parent;
        while (t != null && comp == null)
        {
            comp = t.gameObject.GetComponent<T>();
            t = t.parent;
        }
        return comp;
    }



	//MAX!
	public void InstantiateMod()
	{


		if (map.cursorCountryIndex != -1 
			&& map.countries[map.cursorCountryIndex].data.notEliminated 
			&& !map.countries[map.cursorCountryIndex].data.modQueue.Contains(ModName)
			&& !map.countries[map.cursorCountryIndex].data.genericQueue.Contains(ModName))
        {

			//double check ui

			map.modTargetIndex = map.cursorCountryIndex;
            //Debug.Log(ModName);
			map.modName = ModName;

			confirmPopup.SetActive (true);

            //GameObject mod = Instantiate(Resources.Load("Prefabs/Mods/" + ModName + "Mod", typeof(GameObject))) as GameObject;

		} else {
			//
		}
	}
		
}
