using UnityEngine;
using System.Collections;

[RequireComponent (typeof(SpriteRenderer))]

public class Tiling : MonoBehaviour {

    public int offsetX = 2; //offset så att det hinner spawna en tile innan kameran är framme.

    public bool hasARightBuddy = false;
    public bool hasALeftBuddy = false;

    public bool reverseScale = false; //Används om objektet inte är tilable

    private float spriteWidth = 0f; //Bredden på texturen
    private Camera cam;
    private Transform myTransform;

    void Awake () {
        cam = Camera.main;
        myTransform = transform;
    }

	// Use this for initialization
	void Start () {
        SpriteRenderer sRenderer = GetComponent<SpriteRenderer>();
        spriteWidth = sRenderer.sprite.bounds.size.x;
	}
	
	// Update is called once per frame
	void Update () {

        if (cam == null)
        {
            cam = Camera.main;
        }

        //Behöver den skapa fler texturer? Om inte så gör inget.
	if (hasALeftBuddy == false || hasARightBuddy == false) {
            //Beräknar 50% mer av vad kameran kan se på bredden i världen.
            float camHorizontalExtend = cam.orthographicSize * Screen.width / Screen.height;

            // Beräknar x-positionen där kameran kan se kanten av texturen
            float edgeVisiblePositionRight = (myTransform.position.x + spriteWidth / 2) - camHorizontalExtend;
            float edgeVisiblePositionLeft = (myTransform.position.x - spriteWidth / 2) + camHorizontalExtend;

            //Kollar om kamerans kant och texturens kant korsas. Om de gör det så kallar vi på MakeNewBuddy.
            if (cam.transform.position.x >= edgeVisiblePositionRight - offsetX && hasARightBuddy == false)
            {
                MakeNewBuddy(1);
                hasARightBuddy = true;
            }
            else if (cam.transform.position.x <= edgeVisiblePositionLeft + offsetX && hasALeftBuddy == false)
            {
                MakeNewBuddy(-1);
                hasALeftBuddy = true;
            }
        }
	}

    // En funktion som skapar en ny textur på sidan det behövs.
    void MakeNewBuddy (int rightOrLeft) {
        // Beräknar den nya positionen för nästa extra textur.
        Vector3 newPosition = new Vector3(myTransform.position.x + spriteWidth * rightOrLeft, myTransform.position.y, myTransform.position.z);
        // instansierar vår nya textur och sparar den i en variabel.
        Transform newBuddy = Instantiate (myTransform, newPosition, myTransform.rotation) as Transform;

        //Om tiling inte fungerar, då vänder vi x storleken av objektet så att texturerna ser bra ut ihop.
        if (reverseScale == true) {
            newBuddy.localScale = new Vector3(newBuddy.localScale.x * -1, newBuddy.localScale.y, newBuddy.localScale.z);
        }

        newBuddy.parent = myTransform.parent;
        if (rightOrLeft > 0) {
            newBuddy.GetComponent<Tiling>().hasALeftBuddy = true;
        }
        else {
            newBuddy.GetComponent<Tiling>().hasARightBuddy = true;
        }
    }
}
