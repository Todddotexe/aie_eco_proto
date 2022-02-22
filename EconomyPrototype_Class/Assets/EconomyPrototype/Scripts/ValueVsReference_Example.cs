using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueVsReference_Example : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Pet someOtherPet = new Pet();
        someOtherPet.Species = "Kangaroo";

        Pet possiblyIllegal = someOtherPet;

        Debug.Log($"someOtherPet: {someOtherPet.Species}");
        Debug.Log($"possiblyIllegal: {possiblyIllegal.Species}");

        possiblyIllegal.Species = "Koala";

        Debug.Log($"someOtherPet: {someOtherPet.Species}");
        Debug.Log($"possiblyIllegal: {possiblyIllegal.Species}");

        //------------

        Vector3 somePosition = new Vector3(1,2,3);
        Vector3 otherPosition = somePosition;

        Debug.Log($"somePosition:{somePosition}");
        Debug.Log($"otherPosition:{otherPosition}");

        otherPosition.x = -10;

        Debug.Log($"somePosition:{somePosition}");
        Debug.Log($"otherPosition:{otherPosition}");
    }
}
