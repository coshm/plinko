using UnityEngine;
using System.Collections;

public class ScoreTile : MonoBehaviour {

    [SerializeField] private float score;
    private ScoreBoard scoreBoard;

    void Start() {
        scoreBoard = ScoreBoard.Instance;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag.Equals("Puck")) {
            scoreBoard.AddScore(score);
            collider.gameObject.GetComponent<PuckController>().CompleteDrop();
        }
    }
}
