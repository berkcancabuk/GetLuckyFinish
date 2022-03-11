using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hanger : MonoBehaviour
{
    public ParticleSystem starsEffect;
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Player")
        {
            starsEffect.gameObject.transform.rotation = Quaternion.Euler(-90, 0, 0);
            Instantiate(starsEffect, new Vector3(this.transform.position.x, other.transform.position.y, this.transform.position.z), starsEffect.gameObject.transform.rotation);
            //Instantiate(flareEffect, new Vector3(other.transform.position.x, other.transform.position.y + 1.468f, other.transform.position.z), Quaternion.identity);
            this.gameObject.SetActive(false);
        }
        
        
    }
}
