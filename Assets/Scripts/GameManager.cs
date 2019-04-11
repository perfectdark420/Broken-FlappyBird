using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlappyBird
{
    public class GameManager : MonoBehaviour
    {
        public bool gameOver = false;
        public float scrollSpeed = -1.5f;
        public int score = 0;

        public static GameManager Instance = null;

        public delegate void ScoreAddedCallback(int score);
        public event ScoreAddedCallback scoreAdded;

        // Use this for initialization
        void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(this);
        }

        public void BirdScored()
        {
            // The bird cant score if there is a game over
            if(gameOver)
                return;

            // Increase the score
            score++;

            // Call an event to state that a score has been added
            if (scoreAdded != null)
                scoreAdded.Invoke(score);
        }

        public void BirdDied()
        {
            // Set game over to true
            gameOver = true;
        }
    }
}