using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    float x = 1.939f;
    double y = 1.939;
    decimal z = 9.3944m;
    int c = 83;
    bool b = false;
    char s = 'Z';
    string v = "Good Game";
    string m = "112";
    
    void Start()
    {
        int a = int.Parse(m);
        float tt = (float)y;
        int b = (int)z;
        float r = c;
        Debug.Log("�������������� ������ � �����: "+a.ToString());
        Debug.Log("�������������� double �� float: "+tt.ToString());
        Debug.Log("�������������� decimal � int: " + b.ToString());
        Debug.Log("�������������� int �� float: " + r.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
