using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayAndListExample : MonoBehaviour
{
    [SerializeField]
    public GameObject Prefab;

    public void ShrinkSphere(int index)
    {
        m_SpheresArray[index].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }

    public void ShrinkSphere2()
    {
        for(int i = 0; i < m_SpheresArray.Length / 2; i++)
        {
            m_SpheresArray[i].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
    }

    public void AddSphere()
    {
        GameObject newSphere = Instantiate(Prefab);

        int lastSphereIndex = m_SpheresList.Count - 1;
        GameObject lastSphere = m_SpheresList[lastSphereIndex];

        Vector3 pos = lastSphere.transform.position;
        pos.x = pos.x + 1;

        newSphere.transform.position = pos;
        m_SpheresList.Add(newSphere);   
    }

    public void RemoveSphere()
    {
        int lastSphereIndex = m_SpheresList.Count - 1;
        GameObject lastSphere = m_SpheresList[lastSphereIndex];
        m_SpheresList.RemoveAt(lastSphereIndex);
        Destroy(lastSphere);
    }

    void Start()
    {
        m_SpheresArray = new GameObject[10];

        for (int i = 0; i < m_SpheresArray.Length; i++)
        {
            m_SpheresArray[i] = Instantiate(Prefab);
            m_SpheresArray[i].transform.position = new Vector3(i, 0, 0);
        }

        m_SpheresList = new List<GameObject>();

        for (int i = 0; i < 3 ; i++)
        {
            GameObject sphere = Instantiate(Prefab);
            m_SpheresList.Add(sphere);
            sphere.transform.position = new Vector3(i, 2, 0);
        }
    }

    [NonSerialized]
    private GameObject[] m_SpheresArray;

    [NonSerialized]
    private List<GameObject> m_SpheresList;
}
