using System.Collections.Generic;
using UnityEngine;

public class Pooler : MonoBehaviour
{
    [SerializeField] List<GameObject> pool = new List<GameObject>();
    [SerializeField] Movement movementScript;
    [SerializeField] float timee;
    [SerializeField] float initialTimee;
    [SerializeField] float initialZpos;
    [SerializeField] float disableWhenZposEqual;
    [SerializeField] float yPos;
    private void Update()
    {
        timee -= Time.deltaTime;
        if (timee <= 0)
        {
            if (initialTimee > .5f)
                initialTimee -= .1f;

            timee = initialTimee;
            Spawn();
            Unspawn();
        }

    }
    private void Spawn()
    {
        foreach (GameObject item in pool)
        {
            if (!item.activeInHierarchy)
            {
                item.transform.position = new Vector3(Random.Range(-1, 2) * movementScript.Step,
                    yPos,
                   initialZpos);
                item.SetActive(true);
                break;
            }


        }
    }
    void Unspawn()
    {
        foreach (GameObject item in pool)
        {
            if (item.activeInHierarchy && item.transform.position.z <= disableWhenZposEqual)
            {
                item.SetActive(false);
            }
        }

    }
}
