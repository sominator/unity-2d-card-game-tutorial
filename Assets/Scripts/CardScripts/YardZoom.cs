using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class YardZoom : NetworkBehaviour
{
    public GameObject DisplayArea;

    private GameObject zoomCard;

    void Start()
    {
        DisplayArea = GameObject.Find("DisplayArea");    
    }

    public void OnHoverEnter()
    {
        if (transform.childCount != 0)
        {
            foreach (Transform child in transform)
            {
                zoomCard = Instantiate(child.gameObject, new Vector2(0, 0), Quaternion.identity);
                zoomCard.layer = LayerMask.NameToLayer("Zoom");
                zoomCard.transform.SetParent(DisplayArea.transform, false);

                RectTransform rect = zoomCard.GetComponent<RectTransform>();
                rect.sizeDelta = new Vector2(240, 344);
            }
        }
    }

    public void OnHoverExit()
    {
        if (DisplayArea.transform.childCount != 0)
        {
            foreach(Transform child in DisplayArea.transform)
            {
                Destroy(child.gameObject);
            }
        }
    }
}
