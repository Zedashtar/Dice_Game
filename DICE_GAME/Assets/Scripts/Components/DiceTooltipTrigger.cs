using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceTooltipTrigger : MonoBehaviour
{
    public Dice dice;
    public TooltipFaceComponent tooltip;



    private void Awake()
    {
        Debug.Log("working");
        dice = GetComponent<Dice>();
    }

    void DisplayTooltip()
    {
        TooltipDiceComponent.Show(dice);
    }

    private void OnMouseEnter()
    {
        TooltipDiceComponent.mo = true;
        Invoke("DisplayTooltip", 0.5f);

    }

    private void OnMouseExit()
    {
        TooltipDiceComponent.mo = false;
        TooltipDiceComponent.Hide();
    }

}













