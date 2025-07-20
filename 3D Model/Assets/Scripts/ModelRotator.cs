// Filename: ModelRotator.cs

using UnityEngine;

public class ModelRotator : MonoBehaviour
{
    // You can change this speed in the Inspector to make rotation faster or slower.
    [Tooltip("The speed at which the model rotates when dragged.")]
    public float rotationSpeed = 20f;

    // This is a special Unity function that is called every frame the mouse/finger is held down over an object with a Collider.
    private void OnMouseDrag()
    {
        // Get the horizontal movement of the mouse/finger since the last frame.
        float horizontalInput = Input.GetAxis("Mouse X");

        // Calculate the rotation amount based on input and speed.
        // We use -horizontalInput for a more natural "grabbing and spinning" feel.
        float rotationAmount = -horizontalInput * rotationSpeed * Time.deltaTime;

        // Rotate the object around the world's vertical axis (Vector3.up).
        // Using Space.World ensures it always spins around a fixed Y-axis, which is more stable.
        transform.Rotate(Vector3.up, rotationAmount, Space.World);
    }
}