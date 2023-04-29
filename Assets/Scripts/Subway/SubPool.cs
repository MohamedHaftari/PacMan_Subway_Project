using UnityEngine;
using System.Collections.Generic;

public class SubPool : MonoBehaviour
{
    [SerializeField] float enablingAnotherBlockZpos;
    [SerializeField] float disableWhenZposEqual;
    [SerializeField] BlocksPooler blocksPoolerScript;
    bool enableItOnce=true;
    public bool EnableItOnce { get { return enableItOnce; } set { enableItOnce = value; } }
    private void Update()
    {
        if (transform.position.z <= enablingAnotherBlockZpos&&enableItOnce)
        {
            enableItOnce = false;
            blocksPoolerScript.Spawn(gameObject);
        }
        if (transform.position.z <= disableWhenZposEqual)
        {
            blocksPoolerScript.Unspawn(gameObject);
        }
    }

   
}
