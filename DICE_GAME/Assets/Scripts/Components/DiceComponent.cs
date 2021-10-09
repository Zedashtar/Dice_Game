using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceComponent : MonoBehaviour
{

    Dice dice;
    Rigidbody rb;

    private void Awake()
    {
        dice = GetComponent<Dice>();
        GameObject[] faceGO = GameObject.FindGameObjectsWithTag("Dice Face");
        foreach (GameObject face in faceGO)
        {
            if (face.transform.IsChildOf(this.transform))
                dice.go_faceList.Add(face);

        }
        dice.so_faceList.AddRange(new DiceFace_SO[6]);

        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        dice.InitDice();

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            dice.activeFace = null;
            float dirX = Random.Range(0, 500);
            float dirY = Random.Range(0, 500);
            float dirZ = Random.Range(0, 500);
            transform.position = new Vector3(0, 6, 0);
            transform.rotation = Quaternion.identity;
            rb.AddForce(transform.up * 500);
            rb.AddTorque(dirX, dirY, dirZ);



        }
    }

}
