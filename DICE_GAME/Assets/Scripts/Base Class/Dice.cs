using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{

    List<GameObject> go_faceList = new List<GameObject>();

    [HideInInspector]
    public List<DiceFace_SO> so_faceList = new List<DiceFace_SO>();
    Rigidbody rb;


    [Header("Dice Colors")]
    public Material m_red;
    public Material m_blue;
    public Material m_green;
    public Material m_none;

    [Space]
    [Space]
    [Header("Data")]
    public Dice_SO dice_SO;

    [Space]
    public DiceFace_SO activeFace;




    private void Awake()
    {
        GameObject[] faceGO = GameObject.FindGameObjectsWithTag("Dice Face");
        foreach (GameObject face in faceGO)
        {
            if (face.transform.IsChildOf(this.transform))
                go_faceList.Add(face);
            
        }
        so_faceList.AddRange(new DiceFace_SO[6]);

        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        InitDice();
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            activeFace = null;
            float dirX = Random.Range(0, 500);
            float dirY = Random.Range(0, 500);
            float dirZ = Random.Range(0, 500);
            transform.position = new Vector3(0, 6, 0);
            transform.rotation = Quaternion.identity;
            rb.AddForce(transform.up * 500);
            rb.AddTorque(dirX, dirY, dirZ);



        }
    }


    public void InitDice()
    {
        if (dice_SO == null)
        {
            Debug.LogError("No Dice_SO detected !");
            return;
        }

        foreach (DiceFace_SO face in dice_SO.faces)
        {
            if (face == null)
            {
                Debug.LogError("A Face in " + dice_SO.name + " is missing !");
                return;
            }
        }


        switch (dice_SO.diceType)
        {
            case Dice_SO.DiceType.Double:
                for (int i = 0; i < go_faceList.Count; i++)
                {
                    if (i < 3)
                    {
                        go_faceList[i].GetComponent<MeshRenderer>().material = MaterialSelect(dice_SO.faces[0].faceType);
                        go_faceList[i].GetComponentInChildren<SpriteRenderer>().sprite = dice_SO.faces[0].icon;
                        so_faceList[i] = dice_SO.faces[0];
                    }

                    else
                    {
                        go_faceList[i].GetComponent<MeshRenderer>().material = MaterialSelect(dice_SO.faces[1].faceType);
                        go_faceList[i].GetComponentInChildren<SpriteRenderer>().sprite = dice_SO.faces[1].icon;
                        so_faceList[i] = dice_SO.faces[1];
                    }
                    
                }
                break;

            case Dice_SO.DiceType.Triple:
                for (int i = 0; i < go_faceList.Count; i++)
                {
                    if (i == 0 || i == 5)
                    {
                        go_faceList[i].GetComponent<MeshRenderer>().material = MaterialSelect(dice_SO.faces[0].faceType);
                        go_faceList[i].GetComponentInChildren<SpriteRenderer>().sprite = dice_SO.faces[0].icon;
                        so_faceList[i] = dice_SO.faces[0];
                    }
                    else if (i == 1 || i == 4)
                    {
                        go_faceList[i].GetComponent<MeshRenderer>().material = MaterialSelect(dice_SO.faces[1].faceType);
                        go_faceList[i].GetComponentInChildren<SpriteRenderer>().sprite = dice_SO.faces[1].icon;
                        so_faceList[i] = dice_SO.faces[1];
                    }
                    else
                    {
                        go_faceList[i].GetComponent<MeshRenderer>().material = MaterialSelect(dice_SO.faces[2].faceType);
                        go_faceList[i].GetComponentInChildren<SpriteRenderer>().sprite = dice_SO.faces[2].icon;
                        so_faceList[i] = dice_SO.faces[2];
                    }

                }
                break;


            default:
                foreach (GameObject face in go_faceList)
                {
                    face.GetComponent<MeshRenderer>().material = m_none;
                    face.GetComponentInChildren<SpriteRenderer>().sprite = null;

                    Debug.LogError("Cannot Find Dice Type");
                }


                break;
        }
    }

    Material MaterialSelect(DiceFace_SO.FaceType type)
    {
        Material mat;

        switch (type)
        {
            case DiceFace_SO.FaceType.Blue:
                mat = m_blue;
                break;

            case DiceFace_SO.FaceType.Green:
                mat = m_green;
                break;

            case DiceFace_SO.FaceType.Red:
                mat = m_red;
                break;

            case DiceFace_SO.FaceType.None:
                mat = m_none;
                break;

            default:
                mat = m_none;
                break;
        }

        return mat;
    }
}
