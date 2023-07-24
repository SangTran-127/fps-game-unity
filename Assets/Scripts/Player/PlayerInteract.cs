using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{

    private Camera myCamera;
    [SerializeField]
    private float distance = 3f;
    [SerializeField]
    private LayerMask mask;
    private PlayerUI playerUI;
    private InputManager inputManager;
    // Start is called before the first frame update
    void Start()
    {
        myCamera = GetComponent<PlayerLook>().myCamera;
        playerUI = GetComponent<PlayerUI>();
        inputManager = GetComponent<InputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        playerUI.UpdateText(string.Empty);
        Ray ray = new Ray(myCamera.transform.position, myCamera.transform.forward);
        RaycastHit hitInfo; // variable to store our collision information

        if (Physics.Raycast(ray, out hitInfo, distance, mask))
        {
            // Xử lý khi có va chạm
             if (hitInfo.collider.GetComponent<Interactable>() != null)
            {
                Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
                playerUI.UpdateText(interactable.promptMessage);
                if (inputManager.onFoot.Interact.triggered)
                {
                    interactable.BaseInteract();
                }
            }
        }
        
    }
}
