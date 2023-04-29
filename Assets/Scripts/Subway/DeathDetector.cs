using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathDetector : MonoBehaviour
{
    [SerializeField] string thisSceneName = "Subway";
    [SerializeField] string theBarrierTag = "Barrier";
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == theBarrierTag)
        {
            print("Dead");
            SceneManager.LoadScene(thisSceneName);
        }
    }
}
