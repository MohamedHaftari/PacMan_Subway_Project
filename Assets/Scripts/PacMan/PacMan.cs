using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PacMan : MonoBehaviour
{
    [SerializeField] int maxLives = 3;
    [SerializeField] int currentLives = 3;
    [SerializeField] float speed = 5.0f;
    [SerializeField] GameObject Player;
    [SerializeField] GameObject parentObject;
    private bool isTrig=false;
    [SerializeField] bool ENTER;
    private Vector3 direction;
    private bool isTimerActive = false;
    [SerializeField] float timeLeft = 10.0f;
    [SerializeField] private int lives;

    // Update is called once per frame
    void Update()
    {




        // Get the horizontal and vertical inputs
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Set the direction based on the input
        if (horizontalInput > 0)
        {
            direction = Vector3.right;
        }
        else if (horizontalInput < 0)
        {
            direction = Vector3.left;
        }
        else if (verticalInput > 0)
        {
            direction = Vector3.up;
        }
        else if (verticalInput < 0)
        {
            direction = Vector3.down;
        }

        // Move Pac-Man in the direction he's facing
        transform.position += direction * speed * Time.deltaTime;

        // Rotate Pac-Man to face the direction he's moving
        if (direction == Vector3.right)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (direction == Vector3.left)
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        else if (direction == Vector3.up)
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        else if (direction == Vector3.down)
        {
            transform.rotation = Quaternion.Euler(0, 0, -90);
        }
       
        bool allInactive = parentObject.GetComponentsInChildren<Transform>(true)
          .Where(t => t.gameObject != parentObject)
          .All(t => !t.gameObject.activeSelf);
        if (allInactive)
        {
            print("win");
        }

       
       
        if (currentLives == 0)
        {
            Player.SetActive(false);
            print("Loser");
            SceneManager.LoadScene("PacMan");
        }


       
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            // Destroy(other.gameObject);
            other.gameObject.SetActive(false);

        }
        if (other.gameObject.CompareTag("Ghost") && !ENTER )
        {
            DecreaseLives();
            isTrig = true;
            ENTER = true;

        }
    }
    void DecreaseLives()
    {
        currentLives--;
        isTrig = false;
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Ghost") && ENTER)
        {
            ENTER= false;
        }
    }
}
  
 

