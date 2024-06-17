using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
   // Create a singleton for this script
   public static GameManager Instance { get; private set;}
   public int score = 0; // A var to track the player's current points
   public TextMeshProUGUI scoreText; // A Var to hold our score text object
   public GameObject victoryText; // A var to hold our victory text object
   public GameObject pickupParent; // A var to hold the pikcup parent game object; this is used to count our pickups; ASSIGN IN EDITOR
   public int totalPickups = 0; // A var to store the total # of pcikups in the scene
   private void Awake() // Awake() is called once when this script enters the scene
   {
       if (Instance == null) // If there is no other copy of this script in the scene...
       {
           Instance = this; // "this' refers to itself
       }
       else // This is NOT the only copy of the GameManager script in the scene...
       {
           //Delete this extra copy of this script
           Debug.LogWarning("Cannot have more than one instance of [GameManager] in the scene! Deleted extra copy");
           Destroy(this.gameObject);
       }
   }
   private void Start()
   {
       score = 0; // Reset the score back to 0 every time the game starts
       UpdateScoreText();
       victoryText.SetActive(false); // Disable the victory text when the game starts
       totalPickups = pickupParent.transform.childCount; // Count how many pickups are in the level
   }
   public void UpdateScore(int amount)
   {
       // Increase the score var by the amount given
       score = score + amount;
       UpdateScoreText();
       if (totalPickups <= 0) // If there are no more pickups in the level...
       {
           WinGame(); // Win The Game
       }
   }
   public void UpdateScoreText()
   {
       scoreText.text = score.ToString(); // Updates the score text from the player's score
   }
   public void WinGame()
   {
       victoryText.SetActive(true); // Enable our victory text
       // Stop the game
   }
   public void GameOver() // A function that is called whenever the player loses the game
  {
      Debug.Log("Wasted");
      Invoke("LoadCurrentLevel", 2f);
  }
  private void LoadCurrentLevel()
  {
      SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex));
  }
}
