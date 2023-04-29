using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitRight : MonoBehaviour
{
    public bool isEnterRight;
    public GameObject Player;
    public Transform Left;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Player.transform.position =new Vector3( Left.transform.position.x,Player.transform.position.y,Player.transform.position.z);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

        }
    }
}
