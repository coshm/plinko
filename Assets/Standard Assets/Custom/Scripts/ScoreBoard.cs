using UnityEngine;
using System.Collections;

public class ScoreBoard : MonoBehaviour {

    private float score;
    private ScoreTileFactory factory;

	// Use this for initialization
	void Start () {
	    factory = gameObject.GetComponent<ScoreTileFactory>();
        score = 0f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI() {
        GUI.Label(new Rect(10, 10, 100, 20), score.ToString());
    }

    public void AddScore(float score, int idx) {
        this.score += score;
        factory.CreateScoreTile(idx); 
    }
}
