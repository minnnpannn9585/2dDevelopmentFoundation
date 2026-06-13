using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionExample : MonoBehaviour
{
    public float a;
    public float b;
    float c;
    
    // Start is called before the first frame update
    void Start()
    {
        c = AddNumbers(a, b);
    }

    public float AddNumbers(float num1, float num2)
    {
        float num3 = num1 + num2;
        return num3;
    }
}
