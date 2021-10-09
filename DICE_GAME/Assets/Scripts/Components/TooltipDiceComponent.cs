using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TooltipDiceComponent : MonoBehaviour
{

    static TooltipDiceComponent current;
    static List<TooltipFaceComponent> display;
    static Transform tooltipTransform;
    public static bool mo;

    public List<TooltipFaceComponent> facesDisplay;


    private void Awake()
    {
        current = this;
        display = facesDisplay;
        tooltipTransform = this.transform;
        current.gameObject.SetActive(false);
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        UpdatePosition();
    }




    public static void Show(Dice _dice)
    {
        if (mo)
        {
            UpdatePosition();
            current.gameObject.SetActive(true);

            foreach (TooltipFaceComponent face in display)
            {
                face.GetIcons(_dice);
            }
        }

        
    }

    public static void Hide()
    {
        current.gameObject.SetActive(false);
    }


    static void UpdatePosition()
    {
        
        Vector2 position = Input.mousePosition;
        tooltipTransform.position = position;
    }

}
