using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public float speed = 6;
    Rigidbody myRigidbody;
    Vector3 velocity;
    int coinCount;
    public Text countText;

	// Use this for initialization
	void Start () {
        myRigidbody = GetComponent<Rigidbody>();
        coinCount = 0;
        SetCountText ();

	}
	
	// Update is called once per frame
	void Update () {
        Vector3 input = new Vector3 (Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 direction = input.normalized;
        velocity = direction * speed;

        if  (Input.GetKey("tab"))
        {
            GoNextLevel();
        }
	}

    void FixedUpdate()
    {
        myRigidbody.position += velocity * Time.fixedDeltaTime;
    }

    void OnTriggerEnter(Collider triggerCollider)
    {
        //  print(triggerCollider.gameObject.name);
        if (triggerCollider.tag == "Coin")
        {
            Destroy(triggerCollider.gameObject);
            coinCount++;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + coinCount.ToString();
    }

    void GoNextLevel()
    {
        Application.LoadLevel(5);
    }
}
