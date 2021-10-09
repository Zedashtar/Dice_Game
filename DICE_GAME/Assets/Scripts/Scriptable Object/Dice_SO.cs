using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CreateAssetMenu(fileName = "so_Dice_New", menuName = "Dice/New Dice")]
public class Dice_SO : ScriptableObject
{
    public string diceName;
    public enum DiceType { Double, Triple };

    public DiceType diceType;
    

    public List<DiceFace_SO> faces = new List<DiceFace_SO>();

    public void UpdateInspector()
    {
        switch (diceType)
        {
            case DiceType.Double:
                if (faces.Count > 2)
                    faces.RemoveRange(2, faces.Count - 2);
                if (faces.Count < 2)
                    faces.AddRange(new DiceFace_SO[2 - faces.Count]);
                break;


            case DiceType.Triple:
                if (faces.Count > 3)
                    faces.RemoveRange(3, faces.Count - 3);
                if (faces.Count < 3)
                    faces.AddRange(new DiceFace_SO[3 - faces.Count]);
                break;



            default:
                break;
        }
    }




#if UNITY_EDITOR
    [CustomEditor(typeof(Dice_SO))]
    public class DiceEditor : Editor
    {

        public override void OnInspectorGUI()
        {

            Dice_SO dice = (Dice_SO)target;

            dice.UpdateInspector();

            EditorGUI.BeginChangeCheck();

            if (EditorGUI.EndChangeCheck())
            {
                dice.UpdateInspector();
            }



            base.OnInspectorGUI();
        }
    }
#endif




}