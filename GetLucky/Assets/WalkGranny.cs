using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class WalkGranny : MonoBehaviour
{

    bool walk;
    bool stop = false;
    [SerializeField] Vector3 pos1;
    [SerializeField] Vector3 pos2;
    [SerializeField] GameObject grannyPos1, grannyPos2;
    [SerializeField] float interpolateTime;
    Animator anim;

    [SerializeField] float rot1;
    [SerializeField] float rot2;
    [SerializeField] float turntoPlayer;
    // Start is called before the first frame update
    void Start()
    {
        walk = true;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (walk && !stop)
        {
            StartCoroutine(Walking());
        }
        else if (stop)
        {
            transform.position += Vector3.zero;
            gameObject.transform.DOKill(walk = false);
            transform.rotation = Quaternion.Euler(0, turntoPlayer, 0);
        }

    }

    IEnumerator Walking()
    {
        walk = false;
        // gameObject.transform.DOMove(pos1, interpolateTime);
        gameObject.transform.DOMove(grannyPos1.transform.position, interpolateTime);
        yield return new WaitForSeconds(interpolateTime - 1f);
        gameObject.transform.DORotate(new Vector3(0, rot1, 0), 0.2f);

        // gameObject.transform.DOMove(pos2, interpolateTime);
        gameObject.transform.DOMove(grannyPos2.transform.position, interpolateTime);
        yield return new WaitForSeconds(interpolateTime - 1f);
        gameObject.transform.DORotate(new Vector3(0, rot2, 0), 0.2f);
        walk = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            stop = true;


        }

    }
}
