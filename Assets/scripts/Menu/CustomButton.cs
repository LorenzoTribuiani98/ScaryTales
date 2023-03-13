using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CustomButton : Button
{
    public List<ElementFade> elements;

    private bool isSelected = false;

    public override void OnSelect(BaseEventData eventData)
    {
        base.OnSelect(eventData);
        isSelected = true;
    }

    public override void OnDeselect(BaseEventData eventData)
    {
        base.OnDeselect(eventData);
        isSelected = false;
    }

    public override void  OnPointerEnter(PointerEventData eventData)
    {
        base.OnPointerEnter(eventData);
        if (!isSelected)
        {
            FindObjectOfType<AudioManager>().Play("ButtonHover");
        }        
    }

}
