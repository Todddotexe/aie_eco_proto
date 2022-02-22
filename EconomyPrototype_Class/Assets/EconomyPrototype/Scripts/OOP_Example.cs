using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OOP_Example : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Pet.DefaultSpecies = "Fish";

        Pet pet1 = new Pet();
        pet1.Species = "Cat";
        pet1.Color = Color.black;
        pet1.Weight = 4.5f;

        Debug.Log($"Pet1: Species: {pet1.Species}; Color: {pet1.Color}; Weight: {pet1.Weight};");

        Pet pet2 = new Pet();
        pet2.Species = "Parrot";
        pet2.Color = Color.green;
        pet2.Weight = 0.5f;

        Debug.Log($"Pet2: Species: {pet2.Species}; Color: {pet2.Color}; Weight: {pet2.Weight};");

        Pet pet3 = new Pet();
        Debug.Log($"Pet3: Species: {pet3.Species}; Color: {pet3.Color}; Weight: {pet3.Weight};");
    }
}
