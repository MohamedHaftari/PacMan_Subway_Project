using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targets : MonoBehaviour
{
    [SerializeField] List<GameObject> targets=new List<GameObject>();
    [SerializeField] GameObject Player;
    [SerializeField] float Timer;
    [SerializeField] float Delay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*for (int i=0;i<targets.Count;i++)
          {

          }
        */
        Delay-=(Time.deltaTime/10);
        Timer += Time.deltaTime;
        foreach(GameObject Target in targets)
        {
            if (Target.gameObject.transform.position.x < Player.transform.position.x)
            {
                Target.gameObject.SetActive(false);  
            }
            if (Timer >= Delay && !Target.gameObject.activeInHierarchy)
            {
                Timer = 0;
                Target.gameObject.transform.position = new Vector3(25f, 1f, Random.Range(-2f, 2f));
                Target.gameObject.SetActive(true);
            }
        }
    }
}
