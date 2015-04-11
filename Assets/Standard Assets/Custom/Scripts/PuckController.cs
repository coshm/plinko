using UnityEngine;
using System.Collections;

public class PuckController : MonoBehaviour {

    public enum PuckState {
        POSITIONING,
        MOUSE_DOWN,
        DROPPING,
        DROP_COMPLETE
    };

    [SerializeField] private float yBound;
    [SerializeField] private Vector2 xBounds;

    private Rigidbody2D puck;
    private PuckState state;
    private Vector2 mouseDown;

    [SerializeField] private float maxForce;
    [SerializeField] private float forceMultiplier;

	// Use this for initialization
	void Start () {
        puck = gameObject.GetComponent<Rigidbody2D>();
        state = PuckState.POSITIONING;
	}
	
	// Update is called once per frame
    void Update() {
        switch (state) {
            case PuckState.POSITIONING:
                MovePuck();
                if (Input.GetMouseButtonDown(0)) {
                    state = PuckState.MOUSE_DOWN;
                    mouseDown = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                }
                break;
            case PuckState.MOUSE_DOWN:
                if (Input.GetMouseButtonUp(0)) {
                    state = PuckState.DROPPING;
                    puck.isKinematic = false;

                    Vector2 mouseUp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    float forceMag = CalculateForceMag(mouseDown, mouseUp);
                    Vector2 forceDir = CalculateForceDir(transform.position, mouseUp);
                    puck.AddForce(forceDir * forceMag, ForceMode2D.Impulse);
                }
                break;
            case PuckState.DROPPING:
                break;
            case PuckState.DROP_COMPLETE:
                if (Input.GetMouseButtonUp(0)) {
                    state = PuckState.POSITIONING;
                    puck.isKinematic = true;
                    transform.position = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, yBound);
                }
                break;
        }
	}

    private void MovePuck() {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float x = 0f;
        if (xBounds.x > mousePos.x) {
            x = xBounds.x;
        } else if (xBounds.y < mousePos.x) {
            x = xBounds.y;
        } else {
            x = mousePos.x;
        }
        transform.position = new Vector3(x, yBound, 0);
    }

    private float CalculateForceMag(Vector2 mouseDown, Vector2 mouseUp) {
        Vector2 forceVector = mouseUp - mouseDown;
        return Mathf.Min(forceVector.magnitude * forceMultiplier, maxForce);
    }

    private Vector2 CalculateForceDir(Vector2 puckPos, Vector2 mouseUp) {
        Vector2 dir = mouseUp - puckPos;
        Vector2 dirNorm = dir.normalized;

        return (mouseUp - puckPos).normalized;
    }

    public void CompleteDrop() {
        state = PuckState.DROP_COMPLETE;
    }
}
