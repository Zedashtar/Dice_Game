using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckZoneComponent : MonoBehaviour
{
    private void OnTriggerStay(Collider col)
    {

        

        if (col.GetComponentInParent<Dice>() != null && col.GetComponentInParent<Rigidbody>() != null)
        {
            

            Dice dice = col.GetComponentInParent<Dice>();
            Rigidbody rb = col.GetComponentInParent<Rigidbody>();

            if (rb.velocity == Vector3.zero)
            {


                switch (col.gameObject.name)
                {
                    case "Side0":
                        
                        dice.activeFace = dice.so_faceList[0];
                        break;

                    case "Side1":
                        dice.activeFace = dice.so_faceList[1];
                        break;

                    case "Side2":
                        dice.activeFace = dice.so_faceList[2];
                        break;

                    case "Side3":
                        dice.activeFace = dice.so_faceList[3];
                        break;

                    case "Side4":
                        dice.activeFace = dice.so_faceList[4];
                        break;

                    case "Side5":
                        dice.activeFace = dice.so_faceList[5];
                        break;

                    default:
                        Debug.LogError(dice.dice_SO.name + " faces name not valid !");
                        break;
                }
            }


        }

    }
}
