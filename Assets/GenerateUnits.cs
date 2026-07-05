using UnityEngine;

public class GenerateUnits : MonoBehaviour
{
    public Unit prefab;
    public int rings = 10;

    private void Start()
    {
        const float ringSpacing = 2.0f;
        const float startRadius = 2.0f;
        for (int i = 0; i < rings; i++)
        {
            float radius = startRadius + i * ringSpacing;
            int unitsInRing = Mathf.CeilToInt(Mathf.PI * radius);
            float angle = 0;
            Vector3 position = new Vector3(radius, 0.5f, 0);
            for (int j = 0; j < unitsInRing; j++)
            {
                Unit unit = Instantiate(prefab, position, Quaternion.identity);
                angle += 2 * Mathf.PI / unitsInRing;
                float x = Mathf.Cos(angle) * radius;
                float z = Mathf.Sin(angle) * radius;
                position = new Vector3(x, 0.5f, z);
                unit.SetTarget(position);
            }
        }
    }
}
