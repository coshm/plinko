using UnityEngine;
using System.Collections;

public class ScoreBoard : Singleton<ScoreBoard> {

    private float totalScore;

	// Use this for initialization
	void Start () {
        totalScore = 0f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI() {
        GUI.Label(new Rect(10, 10, 100, 20), totalScore.ToString());
    }

    public void AddScore(float score) {
        this.totalScore += score;
    }
}
