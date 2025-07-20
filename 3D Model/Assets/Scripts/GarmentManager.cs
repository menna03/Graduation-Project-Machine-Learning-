// Filename: GarmentManager.cs
// This script manages which piece of clothing is currently active in the scene.

using UnityEngine;

public class GarmentManager : MonoBehaviour
{
    [Header("Garment Prefabs")]
    [Tooltip("Drag your Jean Prefab from the Assets folder here.")]
    public GameObject jeanPrefab;
    [Tooltip("Drag your T-shirt Prefab from the Assets folder here.")]
    public GameObject tshirtPrefab;
    [Tooltip("Drag your Jacket Prefab from the Assets folder here.")]
    public GameObject jacketPrefab;
    // Add more public GameObjects for shorts, skirts, etc.

    [Header("Scene References")]
    [Tooltip("Drag the GameManager object from your Hierarchy here.")]
    public GarmentCustomizer garmentCustomizer; // The script that applies textures
    [Tooltip("The camera's orbit script, to set its target.")]
    public CameraOrbit cameraOrbit; // The script that controls the camera

    // This variable will hold a reference to the currently active clothing model.
    private GameObject currentGarmentObject;

    // This function will be called by your "Show T-shirt" UI button.
    public void ShowTshirt()
    {
        // Pass the T-shirt prefab to our helper function.
        ActivateGarment(tshirtPrefab);
    }

    // This function will be called by your "Show Jeans" UI button.
    public void ShowJeans()
    {
        ActivateGarment(jeanPrefab);
    }

    // This function will be called by your "Show Jacket" UI button.
    public void ShowJacket()
    {
        ActivateGarment(jacketPrefab);
    }

    // This is the core logic for switching models.
    private void ActivateGarment(GameObject garmentPrefab)
    {
        // If there's already a piece of clothing in the scene, destroy it first.
        if (currentGarmentObject != null)
        {
            Destroy(currentGarmentObject);
        }

        // Check if a valid prefab was provided.
        if (garmentPrefab != null)
        {
            // Create a new instance of the chosen prefab at the center of the scene.
            currentGarmentObject = Instantiate(garmentPrefab, Vector3.zero, Quaternion.identity);

            // --- THIS IS THE CRITICAL WIRING STEP ---
            // Tell the GarmentCustomizer which model is now the active target.
            garmentCustomizer.targetGarment = currentGarmentObject;

            // Tell the CameraOrbit script what to look at and orbit around.
            cameraOrbit.target = currentGarmentObject.transform;

            Debug.Log(garmentPrefab.name + " has been activated.");
        }
    }
}