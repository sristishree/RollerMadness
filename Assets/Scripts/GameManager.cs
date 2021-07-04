using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class GameManager : MonoBehaviour {

	public static GameManager gm;

	[Tooltip("If not set, the player will default to the gameObject tagged as Player.")]
	public GameObject player;

	public enum gameStates {Playing, Death, GameOver, BeatLevel};
	public gameStates gameState = gameStates.Playing;

    public bool HasEndZone = false;
	public int score=0;
	public bool canBeatLevel = false;
	public int beatLevelScore=0;

	public GameObject mainCanvas;
	public Text mainScoreDisplay;
    public Text healthPointDisplay;
	public GameObject gameOverCanvas;
	public Text gameOverScoreDisplay;

	[Tooltip("Only need to be set if canBeatLevel is set to true.")]
	public GameObject beatLevelCanvas;

	public AudioSource backgroundMusic;
	public AudioClip gameOverSFX;
    private float volume = 0.7f;

    //Camera is needed to play audio because it has the audio listener
    public GameObject cam;

    [Tooltip("Only need to be set if canBeatLevel is set to true.")]
	public AudioClip beatLevelSFX;

	private Health playerHealth;
    private EndZoneCheck endzone;

	void Start () {
		if (gm == null) 
			gm = gameObject.GetComponent<GameManager>();

		if (player == null) {
			player = GameObject.FindWithTag("Player");
		}

        if (cam == null)
        {
            cam = GameObject.FindWithTag("MainCamera");
        }
        
        //Player health script reference
		playerHealth = player.GetComponent<Health>();

        //Player endzone reached script reference
        endzone = player.GetComponent<EndZoneCheck>();

		// setup score display
		Collect (0);

		// make other UI inactive
		gameOverCanvas.SetActive (false);
		if (canBeatLevel)
			beatLevelCanvas.SetActive (false);
	}

	void Update () {
        if (healthPointDisplay!=null)
            healthPointDisplay.text = "Health Points: " + playerHealth.healthPoints;
		switch (gameState)
		{
			case gameStates.Playing:
				if (playerHealth.isAlive == false)
				{
					// update gameState
					gameState = gameStates.Death;

					// set the end game score
					gameOverScoreDisplay.text = mainScoreDisplay.text;

					// switch which GUI is showing		
					mainCanvas.SetActive (false);
					gameOverCanvas.SetActive (true);
				}

                else if (canBeatLevel && score>=beatLevelScore) {
                    // update gameState

                    if ((HasEndZone && endzone.gameCompleted) || !HasEndZone)
                    {
                        // hide the player so game doesn't continue playing
                        player.SetActive(false);

                        // switch which GUI is showing			
                        mainCanvas.SetActive(false);
                        beatLevelCanvas.SetActive(true);
                        gameState = gameStates.BeatLevel;
                    }
                    7
				}
				break;
			case gameStates.Death:
				backgroundMusic.volume -= 0.01f;
				if (backgroundMusic.volume<=0.0f) {
					AudioSource.PlayClipAtPoint (gameOverSFX,cam.transform.position,volume);

					gameState = gameStates.GameOver;
				}
				break;
			case gameStates.BeatLevel:
				backgroundMusic.volume -= 0.01f;
				if (backgroundMusic.volume<=0.0f) {
					AudioSource.PlayClipAtPoint (beatLevelSFX,cam.transform.position,volume);
                    //How to play in loop?
					
					gameState = gameStates.GameOver;
				}
				break;
			case gameStates.GameOver:
				// nothing
				break;
		}

	}


	public void Collect(int amount) {
		score += amount;
		if (canBeatLevel) {
			mainScoreDisplay.text = "Score: " + score.ToString () + " of "+ beatLevelScore.ToString ();
		} else {
			mainScoreDisplay.text = "Score: " + score.ToString ();
		}

	}
}
