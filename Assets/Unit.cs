using UnityEngine;

public class Unit : MonoBehaviour
{
    private Vector3 target;

    private void Awake()
    {
        enabled = false;
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.color = Color.white;
    }

    public void SetTarget(Vector3 newTarget)
    {
        target = newTarget;
        enabled = true;
    }

    private void Update()
    {
        Vector3 position = Vector3.MoveTowards(transform.position, target, Time.deltaTime);
        Quaternion rotation = Quaternion.LookRotation(target - transform.position);
        transform.SetPositionAndRotation(position, rotation);
        if (position == target)
        {
            enabled = false;
        }
    }

    public void Highlight(bool highlight)
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.color = highlight ? Color.yellow : Color.white;
    }
}
