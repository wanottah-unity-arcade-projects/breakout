
using UnityEngine;


//
// Breakout [Atari 1976] v2013.07.25
//
// v2023.12.29
//


public class Player1Controller : MonoBehaviour
{
    public static Player1Controller player1;

    public Transform rightBoundary;
    public Transform leftBoundary;

    public Transform paddleTransform;

    public Rigidbody2D paddleRigidbody;

    // speed of paddle
    public float paddleSpeed;

    public float paddleLength;

    //public float paddleDirection;
    public Vector2 paddleDirection;

    // player start position
    private float paddlePositionX;

    private float paddlePositionY;

    //private float paddlePositionOffset;

    private Vector2 paddleStartPosition;


    private void Awake()
    {
        player1 = this;
    }


    private void Update()
    {
        PaddleController();
    }


    private void FixedUpdate()
    {
        paddleRigidbody.velocity = paddleDirection * paddleSpeed;
    }


    public void Initialise()
    {
        // direction of paddle
        //paddleDirection = GameController.STOPPED;

        // reset player 1 start position
        paddlePositionX = 0f;

        paddlePositionY = -9.16f; //-11.95f;

        //paddlePositionOffset = 0.5f;

        paddleLength = 3f;

        paddleStartPosition = new Vector2(paddlePositionX, paddlePositionY);

        paddleTransform.position = paddleStartPosition;

        // speed of paddle
        paddleSpeed = 10f; //6f;
    }


    private void PaddleController()
    {
        if (GameController.gameController.canPlay || GameController.gameController.inAttractMode)
        {
            PlayerInput();
        }
    }


    private void PlayerInput()
    {
        KeyboardController();
    }


    // player 1
    private void KeyboardController()
    {
        //paddleDirection = GameController.STOPPED;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            //paddleDirection = GameController.RIGHT;

            MoveRight();
        }


        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            //paddleDirection = GameController.LEFT;

            MoveLeft();
        }

        else
        {
            paddleDirection = new Vector2(paddlePositionX, GameController.STOPPED);
        }
    }


    private void MoveRight()
    {
        /*paddleTransform.position =
            new Vector2(paddleTransform.position.x + paddleSpeed * Time.deltaTime, paddleTransform.position.y); //, paddleTransform.position.z);

        if (paddleTransform.position.x > rightBoundary.position.x)
        {
            paddleTransform.position = new Vector2(rightBoundary.position.x, paddleTransform.position.y);
        }*/

        paddleDirection = new Vector2(GameController.RIGHT, paddlePositionY);
    }


    private void MoveLeft()
    {
        /*paddleTransform.position =
            new Vector2(paddleTransform.position.x - paddleSpeed * Time.deltaTime, paddleTransform.position.y); //, paddleTransform.position.z);

        if (paddleTransform.position.x < leftBoundary.position.x)
        {
            paddleTransform.position = new Vector2(leftBoundary.position.x, paddleTransform.position.y);
        }*/

        paddleDirection = new Vector2(GameController.LEFT, paddlePositionY);
    }


} // end of class
