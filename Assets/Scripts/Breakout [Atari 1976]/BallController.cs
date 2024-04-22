
using System.Collections;

using UnityEngine;


//
// Breakout [Atari 1976] v2013.07.25
//
// v2023.12.29
//


public class BallController : MonoBehaviour
{
    public static BallController ballController;

    public Transform ballTransform;

    public Rigidbody2D ballRigidbody;

    // direction of ball
    private float xBallVelocity;

    private float yBallVelocity;

    public float xBounceDirection;

    public float yBounceDirection;

    // speed of ball
    public float ballSpeed;

    // ball speed increase
    public float ballSpeedIncrease;

    // maximum ball speed
    public float maxBallSpeed;

    // number of times ball hits the paddle
    public int ballHitCounter;

    // ball starting position
    private float ballStartPositionX;

    private float ballStartPositionY;

    //private float paddleLength;

    private float paddleCenter;

    private float ballServeDelay;



    private void Awake()
    {
        ballController = this;
    }


    public void Initialise()
    {
        // set reference to ball's rigidbody component
        //ballRigidbody = ballTransform.GetComponent<Rigidbody2D>();

        // ball speed
        ballSpeed = 2.5f; // 6f;

        // ball bounce speed
        //ballBounceSpeed = 2f;

        // ball speed increase
        ballSpeedIncrease = 0.1f;

        // maximum ball speed
        maxBallSpeed = 5f;

        //ballTransform.gameObject.SetActive(true);

        // randomise player serve
        //ballRigidbody.velocity = new Vector2(RandomServe(ballSpeed), -ballSpeed); // RandomDirection(ballSpeed));
     
        // number of times ball hits the paddle
        ballHitCounter = 0;

        ballStartPositionX = 0f;

        ballStartPositionY = 0f;

        // delays the ball before serving
        ballServeDelay = 3f;

        StartBall(ballSpeed, ballSpeed);
    }


    // start moving the ball
    public void StartBall(float xBallSpeed, float yBallSpeed)
    {
        // randomise player serve
        float randomServeDirection = RandomServe(xBallSpeed);

        float randomBallDirection = RandomDirection(yBallSpeed);

        // activate the ball
        ballTransform.gameObject.SetActive(true);

        ballRigidbody.velocity = new Vector2(randomServeDirection, randomBallDirection) * (ballSpeed + ballSpeedIncrease * ballHitCounter);
    }


    // reset ball
    public void ResetBall(float xVelocity, float yVelocity)
    {
        // reset ball position
        //ballTransform.position = new Vector3(0, 0, 0);

        //ballTransform.gameObject.SetActive(true);

        //ballRigidbody.velocity = new Vector2(RandomServe(xVelocity), -yVelocity);

        // reset ball hit counter
        ballHitCounter = 0;

        // reset ball position
        //ballTransform.position = new Vector3(0, 0, 0);
        ballTransform.position = new Vector2(ballStartPositionX, ballStartPositionY);
    
        // start moving the ball after short delay
        StartCoroutine(DelayBallServe(xVelocity, yVelocity));
    }


    private IEnumerator DelayBallServe(float ballSpeedX, float ballSpeedY)
    {
        yield return new WaitForSeconds(ballServeDelay);

        StartBall(ballSpeedX, ballSpeedY);
    }


    public void FreezeBall()
    {
        xBallVelocity = ballRigidbody.velocity.x;

        yBallVelocity = ballRigidbody.velocity.y;

        ballRigidbody.constraints = RigidbodyConstraints2D.FreezePosition;
    }


    public void ResumeBall()
    {
        ballRigidbody.constraints = RigidbodyConstraints2D.None;

        ballRigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;

        ballRigidbody.velocity = new Vector2(xBallVelocity, yBallVelocity);
    }


    // change angle of ball when bouncing off paddle
    public void PaddleBounce(Transform paddleTransform)
    {
        // increase ball hit counter
        ballHitCounter++;

        // determine which direction the ball should bounce
        if (ballTransform.position.x > GameController.CENTRE_COURT)
        {
            xBounceDirection = -ballSpeed;
        }

        else
        {
            xBounceDirection = ballSpeed;
        }

        // calculate bounce angle
        paddleCenter = paddleTransform.position.x;

        yBounceDirection = (ballTransform.position.x - paddleCenter) * Player1Controller.player1.paddleLength;

        // change angle and speed of ball
        ballRigidbody.velocity = new Vector2(xBounceDirection, yBounceDirection) * (ballSpeed + ballSpeedIncrease * ballHitCounter);
    }


    // determines the serve direction of the ball
    private float RandomServe(float ballSpeed)
    {
        float playerServe;

        // if we are in attract mode or have just started a new game
        //if (gameController.inDemoMode || (gameController.player1Score == 0 && gameController.player2Score == 0))
        if ((GameController.gameController.player1Score == 0 && GameController.gameController.player2Score == 0))
        {
            // randomise player serve
            if (Random.Range(1, 100) > 40)
            {
                // player 1
                playerServe = ballSpeed;

                //gameController.SetBallColour(AtariConsoleController.atariConsoleController.tvMode, GameController.PLAYER_ONE);
            }

            else
            {
                // player 2
                playerServe = -ballSpeed;

                //gameController.SetBallColour(AtariConsoleController.atariConsoleController.tvMode, GameController.PLAYER_TWO);
            }

            // and return the player to serve
            return playerServe;
        }

        // otherwise . . .
        else
        {
            // just return the current ball direction
            return ballSpeed;
        }
    }


    // determines if the ball should move up or down
    private float RandomDirection(float yVelocity)
    {
        float ballDirection;

        if (Random.Range(1, 100) > 20)
        {
            ballDirection = -yVelocity;
        }

        else
        {
            ballDirection = yVelocity;
        }

        return ballDirection;
    }


} // end of class
