using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothrTrigger : MonoBehaviour
{
    public ParticleSystem blood;
    public ParticleSystem smokepuff;
 
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            blood.Play();
            smokepuff.Play();
        }
            
        
    }
    
}
