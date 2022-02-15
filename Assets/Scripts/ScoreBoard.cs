using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
  int score;
  TMP_Text scoreText;

  void Start()
  {
      scoreText = GetComponent<TMP_Text>();
      scoreText.text = $"SCORE: {score.ToString()}";
  }
  public void IncreaseScore(int points)
  {
    score = score + points;
    scoreText.text = $"SCORE: {score.ToString()}";
  }
}
