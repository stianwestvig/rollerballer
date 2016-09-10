using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    public float speed;
    public Rigidbody rigid;
    public GameObject pickups;
    public Text countText;
    public Text winText;

    private int count;
    private int winCondition;
    private SceneController scene;

    void Start() {
        count = 0;
        rigid = GetComponent<Rigidbody>();
        setCountText();
        winText.text = "";
        winCondition = pickups.transform.childCount - 1;
        scene = new SceneController();
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
        if (count > winCondition) {
            winText.text = "Level complete";
            scene.loadNextScene();
        }   
    }
}