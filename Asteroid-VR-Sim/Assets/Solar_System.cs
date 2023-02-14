using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Solar_System : MonoBehaviour
{

    readonly float G = 100f;
    GameObject[] Celestials;

    // Start is called before the first frame update
    void Start()
    {
        Celestials = GameObject.FindGameObjectsWithTag("Celestial");
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    void FixedUpdate()
    {
        Gravity();  
    }

    void Gravity()
    {
        foreach(GameObject a in Celestials)
        {
            foreach(GameObject b in Celestials)
            {
                if(!a.Equals(b))
                {
                    float mass1 = a.GetComponent<Rigidbody>().mass;
                    float mass2 = b.GetComponent<Rigidbody>().mass;
                    float r = Vector3.Distance(a.transform.position, b.transform.position);

                    a.GetComponent<Rigidbody>().AddForce((b.transform.position - a.transform.position).normalized *
                        (G * (mass1 * mass2) / (r * r) )); 
                }
            }
        }
    }

}
