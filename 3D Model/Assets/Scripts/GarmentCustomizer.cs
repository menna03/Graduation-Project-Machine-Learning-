// Filename: GarmentCustomizer.cs
// FINAL DEFINITIVE VERSION - Uses a direct texture reference for Editor testing.

using UnityEngine;

public class GarmentCustomizer : MonoBehaviour
{
    [Header("3D Model Setup")]
    [Tooltip("Drag the GameObject of the active 3D clothing model from your Hierarchy here.")]
    public GameObject targetGarment;

    [Header("--- Editor Testing ---")]
    [Tooltip("For testing in the Editor, assign a test texture here. This will be applied when you click the button.")]
    public Texture2D editorTestTexture;


    private Renderer garmentRenderer;

    void Start()
    {
        Debug.Log("GameManager's GarmentCustomizer script has started. Finding the Renderer component...");
        if (targetGarment != null)
        {
            garmentRenderer = targetGarment.GetComponentInChildren<Renderer>();
            if (garmentRenderer != null)
            {
                Debug.Log("Success! Renderer component was found on object: " + garmentRenderer.gameObject.name);
            }
        }
        if (garmentRenderer == null)
        {
            Debug.LogError("FATAL ERROR: The GarmentCustomizer could not find a Renderer on the assigned 'Target Garment'.");
        }
    }

    public void OnChangeTextureClicked()
    {
        Debug.Log("--- 'Change Garment Texture' Button was Clicked ---");

#if UNITY_EDITOR
            // --- THIS CODE RUNS ONLY IN THE UNITY EDITOR ---
            Debug.Log("Running in Editor mode. Applying the assigned test texture.");
            if (editorTestTexture != null)
            {
                ApplyTexture(editorTestTexture);
            }
            else
            {
                Debug.LogError("Editor test failed: No 'Editor Test Texture' has been assigned in the Inspector!");
            }

#else
        // --- THIS CODE RUNS ONLY ON A REAL DEVICE (Android, iOS) ---
        NativeGallery.GetImageFromGallery((path) =>
        {
            if (path != null)
            {
                Texture2D newTexture = NativeGallery.LoadImageAtPath(path, 2048, false);
                if (newTexture != null)
                {
                    ApplyTexture(newTexture);
                }
                else
                {
                    Debug.LogError("Failed to load texture from device path: " + path);
                }
            }
        }, "Select a Cloth Texture");
#endif
    }

    void ApplyTexture(Texture2D texture)
    {
        if (garmentRenderer == null)
        {
            Debug.LogError("Cannot apply texture because the Renderer is missing!");
            return;
        }

        Debug.Log("Applying texture '" + texture.name + "' to the material's _BaseMap property.");
        garmentRenderer.material.SetTexture("_BaseMap", texture);
        Debug.Log("--- Texture has been applied to the 3D model successfully! ---");
    }
}