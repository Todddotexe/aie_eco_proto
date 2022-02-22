using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pet
{
    // Default Instances
    public static string DefaultSpecies = "Dog";

    public static float DefaultWeight = 1;

    public static Color DefaultColor = Color.white;

    //Instances
    public string Species;

    public float Weight;

    public Color Color;

    public Pet()
    {
        Debug.Log("Constructor of the Pet");
        Species = DefaultSpecies;
    }
}
