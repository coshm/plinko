using UnityEngine;
using System.Collections;

public class ScoreTile : MonoBehaviour {

    private ScoreBoard scoreBoard;
    private float tileScore;
    private int idx;

    public void Inititalize(float tileScore, Color color, int idx, ScoreBoard scoreBoard) {
        this.tileScore = tileScore;
        gameObject.GetComponent<SpriteRenderer>().color = color;
        this.idx = idx;
        this.scoreBoard = scoreBoard;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag.Equals("Puck")) {
            scoreBoard.AddScore(tileScore, idx);
        }
    }
}
