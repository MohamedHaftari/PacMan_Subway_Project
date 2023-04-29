using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitLeft : MonoBehaviour
{
    public bool isEnterLeft;
    public GameObject Player;
    public Transform Right;
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
            Player.transform.position = new Vector3(Right.transform.position.x, Player.transform.position.y, Player.transform.position.z);

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

        }
    }
}
