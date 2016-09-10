using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    public float speed;
    public Rigidbody rigid;
    public Text countText;
    public Text winText;

    private int count;

    void Start() {
        count = 0;
        rigid = GetComponent<Rigidbody>();
        setCountText();
        winText.text = "";
    }

    void FixedUpdate() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        rigid.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Pickup")) {
            other.gameObject.SetActive(false);
            count++;
            setCountText();
        }
    }

    void setCountText() {
        countText.text = "Count: " + count.ToString();
        if (count > 7) {
            winText.text = "You win again, biatch";
        }   
    }
}