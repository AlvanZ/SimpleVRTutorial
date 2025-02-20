using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CannonShoot : MonoBehaviour
{
    public GameObject cannonBallPrefab;
    public Transform firePoint;
    public float shootForce = 10f;

    public void Start()
    {
        UnityEngine.XR.Interaction.Toolkit.Interactables.XRSimpleInteractable interactable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRSimpleInteractable>();
        interactable.selectEntered.AddListener(FireCannon);
    }

    public void FireCannon(SelectEnterEventArgs args)
    {
        GameObject cannonBall = Instantiate(cannonBallPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = cannonBall.GetComponent<Rigidbody>();
        rb.AddForce(firePoint.forward * shootForce, ForceMode.Impulse);
    }
}
