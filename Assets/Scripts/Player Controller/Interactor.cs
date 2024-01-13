using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IInteractable
{
    public void Interact();
}

public class Interactor : MonoBehaviour
{
    private Transform InteractorSource;
    [SerializeField] private float InteractRange;
    // Start is called before the first frame update
    private void Awake()
    {
        InteractorSource = GetComponent<Transform>();
    }

    private void Update()
    {
        Ray r = new Ray(InteractorSource.position, InteractorSource.forward);
        if (Physics.Raycast(r, out RaycastHit HitInfo, InteractRange))
        {
            if (HitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
            {

                Debug.Log("Interactuable");
            }
            //Debug.DrawRay(InteractorSource.position, InteractorSource.forward, Color.red);
        }
    }

    public void Interact()
    {
        Ray r = new Ray(InteractorSource.position, InteractorSource.forward);
        if (Physics.Raycast(r, out RaycastHit HitInfo, InteractRange))
        {
            if (HitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
            {
                interactObj.Interact();
                Debug.Log("Interactor");
            }
        }
    }
}
