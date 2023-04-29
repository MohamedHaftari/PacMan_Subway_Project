using System.Collections;
using UnityEngine;
using TMPro;

public class coinCollector : MonoBehaviour
{
    [SerializeField] string coinTag = "Coin";
    [SerializeField] TMP_Text coinText;
    [SerializeField] int coinScore;
    
    private void OnTriggerEnter(Collider colliderr)
    {
        if (colliderr.transform.tag == coinTag)
        {
            StartCoroutine(WhatHappenedToCoin(colliderr));
            print("coined");
            coinScore++;
            coinText.text = coinScore.ToString();
        }
    }
    IEnumerator WhatHappenedToCoin(Collider colliderr)
    {
        colliderr.gameObject.GetComponent<MeshRenderer>().enabled = false;
        colliderr.enabled = false;
        yield return new WaitForSeconds(1);
        colliderr.gameObject.GetComponent<MeshRenderer>().enabled = true;
        colliderr.enabled = true;

    }
}
