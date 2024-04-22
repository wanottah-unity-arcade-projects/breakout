﻿
using UnityEngine;


//
// Breakout [Atari 1976] v2013.07.25
//
// v2023.12.29
//


public class CollisionController : MonoBehaviour
{
    private float WhereToGo(Vector2 ballPosition, Vector2 paddlePosition)
    {
        return (ballPosition.x - paddlePosition.x) * 4;
    }


    // check if the ball has entered the goal
    private void OnTriggerEnter2D(Collider2D collidingObject)
    {
        if (!GameController.gameController.inAttractMode)
        {
            BallController.ballController.ballTransform.gameObject.SetActive(false);
            
            // play the 'goalScored' sound
            AudioController.audioController.PlayAudioClip("Goal Scored");
        }

        // player 1 goal
        if (collidingObject.CompareTag("Player Goal"))
        {
            // update player 2 score
            //GameController.gameController.UpdateScore(GameController.PLAYER_TWO);

            // reset ball position and speed
            //BallController.ballController.ResetBall(-BallController.ballController.ballSpeed, -BallController.ballController.ballSpeed);
        //}

        // player 2 Goal
        //if (collidingObject.CompareTag("Player 2 Goal"))
        //{
            // update player 1 score
            //GameController.gameController.UpdateScore(GameController.PLAYER_ONE);

            // reset ball position and speed
            BallController.ballController.ResetBall(BallController.ballController.ballSpeed, BallController.ballController.ballSpeed);
        }
    }


    // when the ball bounces off the paddles
    private void OnCollisionEnter2D(Collision2D collidingObject)
    {
        if (!GameController.gameController.inAttractMode)
        {
            if (collidingObject.gameObject.CompareTag("Player 1") || collidingObject.gameObject.CompareTag("Player 2"))
            {
                // play a sound
                AudioController.audioController.PlayAudioClip("Paddle Bounce");

                BallController.ballController.PaddleBounce(collidingObject.transform);
            }
        }

        /*if (collidingObject.gameObject.CompareTag("Player 1") || collidingObject.gameObject.CompareTag("Player 2"))
        {
            float x = WhereToGo(BallController.ballController.ballTransform.position, collidingObject.transform.position);

            Vector2 dir = new Vector2(x, 1f);

            BallController.ballController.ballRigidbody.velocity = dir * BallController.ballController.ballSpeed;
        }*/
    }


    // if ball has collided with the paddle
    /*private void OnCollisionExit2D(Collision2D collidingObject)
    {
        if (collidingObject.gameObject.CompareTag("Player 1"))
        {
            // if the ball's movement speed is less than its maximum speed
            if (BallController.ballController.ballRigidbody.velocity.magnitude < BallController.ballController.maxBallSpeed)
            {
                BallController.ballController.ballRigidbody.velocity =

                    new Vector2(
                        BallController.ballController.ballRigidbody.velocity.x * 
                        BallController.ballController.ballSpeedIncrease, 
                        BallController.ballController.ballRigidbody.velocity.y + 
                        Player1Controller.player1.paddleDirection * BallController.ballController.ballBounceSpeed);
            }


            // otherwise, just change the bounce speed of the ball
            else
            {
                BallController.ballController.ballRigidbody.velocity =

                    new Vector2(
                        BallController.ballController.ballRigidbody.velocity.x, 
                        BallController.ballController.ballRigidbody.velocity.y + 
                        Player1Controller.player1.paddleDirection * BallController.ballController.ballBounceSpeed);
            }
        }


        if (collidingObject.gameObject.CompareTag("Player 2"))
        {
            // if the ball's movement speed is less than its maximum speed
            if (BallController.ballController.ballRigidbody.velocity.magnitude < BallController.ballController.maxBallSpeed)
            {
                BallController.ballController.ballRigidbody.velocity =

                    new Vector2(
                        BallController.ballController.ballRigidbody.velocity.x *
                        BallController.ballController.ballSpeedIncrease, 
                        BallController.ballController.ballRigidbody.velocity.y + 
                        Player2Controller.player2.paddleDirection * BallController.ballController.ballBounceSpeed);
            }


            // otherwise, just change the bounce speed of the ball
            else
            {
                BallController.ballController.ballRigidbody.velocity =

                    new Vector2(
                        BallController.ballController.ballRigidbody.velocity.x, 
                        BallController.ballController.ballRigidbody.velocity.y + 
                        Player2Controller.player2.paddleDirection * BallController.ballController.ballBounceSpeed);
            }
        }
    }*/


} // end of class
