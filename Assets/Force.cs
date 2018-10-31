using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Force : MonoBehaviour {

    public int Collisions;
    private float A;
    private float B;
    private float DifferenceA;
    private float DifferenceB;
    private float Sum;
    private float Average;
    public TextMesh TextA;
    public TextMesh TextB;
    public TextMesh TextC;
    

    // Use this for initialization
    void Start () {
        Physics.gravity = new Vector3(0, 0, -6.35f);
        Collisions = 0;
        A = 0f;
        B = 0f;
        DifferenceA = 0f;
        DifferenceB = 0f;
        Sum = 0f;
        TextA.text = "Number of Collisions: 0";
        TextB.text = "Time between two Collisions: 0";
        TextC.text = "Average Time: 0";

    }
	
	// Update is called once per frame
	void Update () {
           
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Capacitor_A")
        {
            Physics.gravity = new Vector3(0, 0, 6.35f);
            Debug.Log("Capacitor_A");
            Collisions++;
            Debug.Log(Collisions);
            
            A = Time.realtimeSinceStartup;
            Debug.Log(A);
            Debug.Log("A");

            DifferenceA = A - B;


            TextA.text = "Number of Collisions: " + Collisions;
            TextB.text = "Time between two Collisions: " + DifferenceA;

            if (Collisions > 100)
            {

                Sum = Sum + (A - B);

                Average = Sum / (Collisions - 100);

                TextC.text = "Average Time: " + Average;
            }

            Debug.Log(Average);

        }

        else if (col.gameObject.name == "Capacitor_B")
        {
            Physics.gravity = new Vector3(0, 0, -6.35f);
            Debug.Log("Capacitor_B");
            Collisions++;
            Debug.Log(Collisions);
            
            B = Time.realtimeSinceStartup;
            Debug.Log(B);
            Debug.Log("B");

            DifferenceB = B - A;

            Average = ((Average * Collisions) + A) / Collisions;
            TextA.text = "Number of Collisions: " + Collisions;
            TextB.text = "Time between two Collisions: " + DifferenceB;


            if (Collisions > 100)
            {

                Sum = Sum + (B - A);

                Average = Sum / (Collisions - 100);

                TextC.text = "Average Time: " + Average;
            }

            Debug.Log(Average);

        }
    }

    public class TextToFile
    {
       
    }

}
