using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "so_Face_New", menuName ="Dice/Dice Face")]
public class DiceFace_SO : ScriptableObject
{
    public enum FaceType {Blue, Green, Red, None };

    public FaceType faceType;

    public Sprite icon;
    
   




}
