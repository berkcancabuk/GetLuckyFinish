using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ParentScript : MonoBehaviour
{
    GameObject PlayerPath;
    [SerializeField] int levelNumber;
    public float setlookatTime;
    public float pathspeed;
    public float startPoint = 4f;
    
    [SerializeField] GameObject[] Levels;
    // Start is called before the first frame update
    void Start()
    {
        DotweenPath();
        DOTween.Pause("parentween");
    } 
    public void DotweenPath()
    {
        
            Instantiate(Levels[levelNumber], new Vector3(0, 1, startPoint), Quaternion.identity);

            PlayerPath = GameObject.FindWithTag("PlayerPath");

            Vector3[] PathPositions = new Vector3[PlayerPath.transform.childCount];
            for (int i = 0; i < PlayerPath.transform.childCount; i++)
            {
                PathPositions[i] = PlayerPath.transform.GetChild(i).GetChild(0).position;
        }
        GameObject parentgameobje = Levels[levelNumber];
        GameObject child = parentgameobje.transform.GetChild(0).gameObject;
        int a = child.transform.childCount;
        transform.DOPath(PathPositions, a/1.3f, PathType.CatmullRom).SetEase(Ease.Linear).SetLookAt(setlookatTime).SetId("parentween");
       
        
    }
}
