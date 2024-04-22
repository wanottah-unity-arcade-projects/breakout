
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//
// Breakout [Atari 1976] v2013.07.25
//
// v2023.08.02
//


public class BrickController : MonoBehaviour
{
    // score value of brick
    [SerializeField] private int brickScore;


    // when the ball bounces off the bricks
    void OnCollisionEnter2D(Collision2D collidingObject)
    {
        if (!GameController.gameController.inAttractMode)
        {
            //if (collidingObject.gameObject.CompareTag("Player 1") || collidingObject.gameObject.CompareTag("Player 2"))
            //{
                // play a sound
                AudioController.audioController.PlayAudioClip("Paddle Bounce");
            //}

            Destroy(gameObject);
        }
    }


    // update score with brick score
    public void DestroyBrick(int playerHit)
    {
        //Debug.Log("destroybrick: " + "player: " + playerHit + ", hit: " + gameController.player1Hit);
        // see if player hit the ball
        //if (gameController.player1Hit || gameController.player2Hit || gameController.player3Hit || gameController.player4Hit)
        /*if (playerHit > 0)
        {
            //Debug.Log("player1hit: " + gameController.player1Hit);
            // update player's score with brick score
            //gameController.UpdateScore(playerHit, brickScore);

            // create the score effect game object at the position of the brick
            //GameObject brickScoreObject = (GameObject)Instantiate(scoreEffect, transform.position, transform.rotation);

            // set the brick score object as a child of brick scores
            //brickScoreObject.transform.SetParent(brickScores.gameObject.transform);

            // Get a reference to the brick score value text object
            //brickScoreObject.GetComponent<ScoreEffect>().brickScoreValueText.text = brickScore.ToString();
        }*/

        // play a sound
        AudioController.audioController.PlayAudioClip("Paddle Bounce");

        // add score
        //GameController.gameController.UpdateScore(GameController.PLAYER_ONE);

        // destroy brick
        Destroy(gameObject);
    }
    

} // end of class
