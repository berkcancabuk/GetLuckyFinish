using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transparent : MonoBehaviour
{
    public Material gateColor;
    // Start is called before the first frame update
    void Start()
    {
        gateColor.color = new Color(1, 224f / 255f, 0, 1f);

    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gateColor.color = new Color(1, 224f / 255f, 0, 0.1f);
        }
        
    }
    
}
