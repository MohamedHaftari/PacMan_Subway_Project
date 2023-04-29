using UnityEngine;

public class BoxMovement : MonoBehaviour
{
    [SerializeField] Vector3 speed;
    void Update()
    {
        transform.Translate(speed * Time.deltaTime);
    }
}
