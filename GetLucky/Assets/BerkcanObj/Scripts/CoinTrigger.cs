using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CoinTrigger : MonoBehaviour
{
    
    public ParticleSystem particleSystemm;
    private void OnTriggerEnter(Collider other)
    {
        
        
        Instantiate(particleSystemm, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z),
            Quaternion.Euler(-90,0,0));
        this.gameObject.SetActive(false);

    }
   
}
