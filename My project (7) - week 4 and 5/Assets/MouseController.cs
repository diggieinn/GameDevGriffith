using UnityEngine;

public class MouseController : MonoBehaviour {

    // The speed at which the player moves
    public float speed = 10f;

    // The position the player will move towards
    private Vector3 targetPosition;

    // The camera object that will follow the player
    public Transform cameraTransform;

    // The distance between the camera and the player
    public float cameraDistance = 10f;

    void Update () {

        // Check if the left mouse button is clicked
        if (Input.GetMouseButtonDown(0)) {

            // Get the position of the mouse click in world space
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = transform.position.z - Camera.main.transform.position.z;
            targetPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            // Restrict movement to the X and Z axes
            targetPosition.y = transform.position.y;
            targetPosition.x = Mathf.Clamp(targetPosition.x, -10f, 10f);
            targetPosition.z = Mathf.Clamp(targetPosition.z, -10f, 10f);
        }

        // Move the player towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Move the camera to follow the player
        cameraTransform.position = transform.position - transform.forward * cameraDistance;
        cameraTransform.LookAt(transform.position);

    }
}