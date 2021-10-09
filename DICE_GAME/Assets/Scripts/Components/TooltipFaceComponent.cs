using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TooltipFaceComponent : MonoBehaviour
{

    
    Image faceIcon;
    Image icon;
    int index;


    private void Awake()
    {
        faceIcon = GetComponent<Image>();
        icon = transform.Find("Icon").gameObject.GetComponent<Image>();
        index = int.Parse(this.name);
    }


    public void GetIcons(Dice _dice)
    {
        

        faceIcon.sprite = _dice.tooltipList[index].faceIcon;
        icon.sprite = _dice.tooltipList[index].icon;
    }



}
