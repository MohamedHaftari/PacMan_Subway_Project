using System.Collections.Generic;
using UnityEngine;


public class BlocksPooler : MonoBehaviour
{

    [SerializeField] List<GameObject> pool = new List<GameObject>();
    [SerializeField] Vector3 startPos;

    public void Spawn(GameObject go)
    {
        foreach (GameObject item in pool)
        {
            if (!item.activeInHierarchy)
            {
                item.transform.position = go.transform.position + startPos;
                item.SetActive(true);
                item.GetComponent<SubPool>().EnableItOnce = true;
                break;
            }


        }
    }
    public void Unspawn(GameObject go)
    {
        
           if (go.activeInHierarchy)
           {
               go.SetActive(false);
           }
        

    }
}

