using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EconomyPrototype;

public class Resource_Example : MonoBehaviour
{
    [SerializeField]
    public Resource otherResource;
    void Start()
    {
        Resource r1 = new Resource();
        r1.A = 100f;
        r1.B = 150f;
        r1.C = 80f;
        Debug.Log($"r1: A={r1.A}, B={r1.B}, C={r1.C}");

        Resource r2 = ReduceResource(r1);
        Debug.Log($"r2: A={r2.A}, B={r2.B}, C={r2.C}");

        Debug.Log($"r1: A={r1.A}, B={r1.B}, C={r1.C}");

        Resource sum = SumResource(r1, r2);
        Debug.Log($"sum: A={sum.A}, B={sum.B}, C={sum.C}");

        Resource finalResource = r1 + r2;
        Debug.Log($"finalResource: A={finalResource.A}, B={finalResource.B}, C={finalResource.C}");

        Resource less = LessResource(r1, r2);
        Debug.Log($"less: A={less.A}, B={less.B}, C={less.C}");

    }
    private Resource ReduceResource(Resource r)
    {
        r.A = r.A / 2;
        r.B = r.B / 2;
        r.C = r.C / 2;
        return r;
    }

    private Resource SumResource(Resource resource1, Resource resource2)
    {
        Resource result = new Resource();
        result.A = resource1.A + resource2.A;
        result.B = resource1.B + resource2.B;
        result.C = resource1.C + resource2.C;
        return result;
    }

    private Resource LessResource(Resource resource1, Resource resource2)
    {
        Resource lessResult = new Resource();
        lessResult.A = resource1.A - resource2.A;
        lessResult.B = resource1.B - resource2.B;
        lessResult.C = resource1.C - resource2.C;
        return lessResult;
    }

}
