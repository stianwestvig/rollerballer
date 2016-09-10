using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
    public GameObject player;
    private Vector3 offset;

	void Start () {
        offset = transform.position - player.transform.position;
	}

	// Runs every frame, but after all positions have been updated
	void LateUpdate () {
        transform.position = player.transform.position + offset;
	}
}
