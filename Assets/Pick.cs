using UnityEngine;
using UnityEngine.InputSystem;

public class Pick : MonoBehaviour
{
    private Camera cam;
    private Unit unit;

    private void Awake()
    {
        cam = GetComponent<Camera>();
    }

    private void FixedUpdate()
    {
        Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Unit newUnit = hit.collider.GetComponent<Unit>();
            if (newUnit != unit)
            {
                if (unit != null)
                {
                    unit.Highlight(false);
                }
                unit = newUnit;
                if (unit != null)
                {
                    unit.Highlight(true);
                }
            }
        }
    }
}
