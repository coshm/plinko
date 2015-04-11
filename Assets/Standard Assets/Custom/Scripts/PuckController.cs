using UnityEngine;
using System.Collections;

public class PuckController : MonoBehaviour {

    [SerializeField] private float yBound;
    [SerializeField] private Vector2 xBounds;

    private Rigidbody2D puck;
    private bool isMouseDown = false;
    private bool isMouseReleased = false;
    private Vector2 mouseDown;

    [SerializeField] private float maxForce;
    [SerializeField] private float forceMultiplier;

	// Use this for initialization
	void Start () {
        puck = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
    void Update() {
        if (!isMouseReleased) {
            if (Input.GetMouseButtonDown(0)) {
                isMouseDown = true;
                mouseDown = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                print("MOUSE PRESSED");
            }

            if (!isMouseDown) {
                MovePuck();
                print("NEW PUCK POSITION : " + transform.position);
            }

            if (Input.GetMouseButtonUp(0)) {
                print("MOUSE RELEASED");
                isMouseReleased = true;
                isMouseDown = false;
                puck.isKinematic = false;

                Vector2 mouseUp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                float forceMag = CalculateForceMag(mouseDown, mouseUp);
                Vector2 forceDir = CalculateForceDir(transform.position, mouseUp);
                puck.AddForce(forceDir * forceMag, ForceMode2D.Impulse);
            }
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
}
