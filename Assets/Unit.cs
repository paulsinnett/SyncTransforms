using UnityEngine;

public class Unit : MonoBehaviour
{
    private Vector3 target;

    public void SetTarget(Vector3 newTarget)
    {
        target = newTarget;
    }

    private void Update()
    {
        Vector3 position = Vector3.MoveTowards(transform.position, target, Time.deltaTime);
        Quaternion rotation = Quaternion.LookRotation(target - transform.position);
        transform.SetPositionAndRotation(position, rotation);
    }
}
