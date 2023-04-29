using UnityEngine;
using MyLibrary;

public class SwipeDetector : MonoBehaviour
{
    [Tooltip("Increase it to get lower X axis travel detection")]
    [SerializeField] float xDistDetection=20f;
    [Tooltip("Increase it to get lower Y axis travel detection")]
    [SerializeField] float yDistDetection = 20f;
    private Vector2 startPos;
    private bool canSwipe=true;
    private MyXdirection xDir= MyXdirection.idle;
    private MyYdirection yDir= MyYdirection.idle;
    public MyXdirection Xdir {  get { return xDir; } private  set {} }
    public MyYdirection Ydir {  get { return yDir; } private  set {} }
    private void Start()
    {
        canSwipe = true;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPos = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            #region X axis Detection
            if ((Mathf.Abs(startPos.x - Input.mousePosition.x) >= Screen.width / xDistDetection) && canSwipe)
            {
                if (startPos.x < Input.mousePosition.x) //swipeRight
                {
                    canSwipe = false;
                    print("swipeRight");
                    xDir = MyXdirection.right;
                }
                if (startPos.x > Input.mousePosition.x) //swipeLeft
                {
                    canSwipe = false;
                    print("swipeLeft");
                    xDir = MyXdirection.left;
                }
            }
            else xDir = MyXdirection.idle;
            #endregion

            #region Y axis Detection
            if ((Mathf.Abs(startPos.y - Input.mousePosition.y) >= Screen.height / yDistDetection) && canSwipe)
            {
                if (startPos.y < Input.mousePosition.y) //swipeTop
                {
                    canSwipe = false;
                    print("swipeTop");
                    yDir = MyYdirection.top;
                }
                if (startPos.y > Input.mousePosition.y) //swipeDown
                {
                    canSwipe = false;
                    print("swipeDown");
                    yDir = MyYdirection.down;
                }
            }
            else  yDir = MyYdirection.idle;
            #endregion

        }


        if (Input.GetMouseButtonUp(0))
        {
            canSwipe = true;
            xDir = MyXdirection.idle;
            yDir = MyYdirection.idle;
        } 
    }
}
