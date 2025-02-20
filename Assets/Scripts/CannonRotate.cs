using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CannonRotation : MonoBehaviour
{
    public float rotationSpeed = 30f; // Adjust this for speed
    public Transform cannonBarrel; // The part of the cannon you want to rotate (usually the barrel)

    private bool isRotating = false;
    private UnityEngine.XR.Interaction.Toolkit.Interactors.IXRSelectInteractor interactor;

    private void Start()
    {
        UnityEngine.XR.Interaction.Toolkit.Interactables.XRSimpleInteractable interactable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRSimpleInteractable>();
        interactable.selectEntered.AddListener(StartRotation);
        interactable.selectExited.AddListener(StopRotation);
    }

    private void Update()
    {
        if (isRotating && interactor != null)
        {
            // Get controller movement direction
            Transform interactorTransform = interactor.transform;
            float horizontalRotation = interactorTransform.right.x * rotationSpeed * Time.deltaTime;
            float verticalRotation = -interactorTransform.up.y * rotationSpeed * Time.deltaTime;

            // Rotate only the cannon's "look direction" (cannon barrel or similar part)
            cannonBarrel.Rotate(verticalRotation, horizontalRotation, 0, Space.Self);
        }
    }

    public void StartRotation(SelectEnterEventArgs args)
    {
        isRotating = true;
        interactor = args.interactorObject;
    }

    public void StopRotation(SelectExitEventArgs args)
    {
        isRotating = false;
        interactor = null;
    }
}
