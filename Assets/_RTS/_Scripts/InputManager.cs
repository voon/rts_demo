using UnityEngine;
using UnityEngine.AI;

public class InputManager : MonoBehaviour
{
    private Camera mainCamera;
    private RaycastHit hitInfo;
    private Troop selectedTroop;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        HandleSelection();
        HandleMovement();
    }

    private void HandleSelection()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hitInfo))
            {
                Troop clickedTroop = hitInfo.collider.GetComponent<Troop>();
                if (clickedTroop != null)
                {
                    if (selectedTroop)
                        selectedTroop.UnselectTroop();

                    selectedTroop = clickedTroop;
                    selectedTroop.SelectTroop();
                }
            }
        }
    }

    private void HandleMovement()
    {
        if (selectedTroop != null && Input.GetMouseButtonDown(1))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hitInfo))
            {
                Vector3 targetPosition = hitInfo.point;
                selectedTroop.MoveTo(targetPosition, hitInfo.collider.gameObject);
            }
        }
    }
}
