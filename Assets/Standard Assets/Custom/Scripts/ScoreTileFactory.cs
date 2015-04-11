using UnityEngine;
using System.Collections;

public class ScoreTileFactory : MonoBehaviour {

    [SerializeField]
    private Vector3[] positions;

    [SerializeField]
    private Color[] colors;

    [SerializeField]
    private ScoreTile scoreTile;

    private ScoreBoard scoreBoard;

	// Use this for initialization
	void Start () {
        scoreBoard = gameObject.GetComponent<ScoreBoard>();
        for (int idx = 0; idx < positions.Length; idx++) {
            CreateScoreTile(idx);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void CreateScoreTile(int idx) {
        float tileScore = Random.Range(0, 10) * 100f;
        Color color = colors[Random.Range(0, colors.Length)];
        ScoreTile tile = (ScoreTile) Instantiate(scoreTile, positions[idx], Quaternion.identity);
        tile.Inititalize(tileScore, color, idx, scoreBoard);
    }


}
