using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateUnits : MonoBehaviour
{
    public Unit prefab;
    public int rings = 10;
    private readonly List<List<Unit>> ringList = new();
    private const float ringSpacing = 2.0f;
    private const float startRadius = 2.0f;

    private void Start()
    {
        for (int i = 0; i < rings; i++)
        {
            float radius = startRadius + i * ringSpacing;
            int unitsInRing = Mathf.CeilToInt(Mathf.PI * radius);
            List<Unit> list = new();
            float angle = 0;
            Vector3 position = new Vector3(radius, 0.5f, 0);
            for (int j = 0; j < unitsInRing; j++)
            {
                Unit unit = Instantiate(prefab, position, Quaternion.identity);
                list.Add(unit);
                angle += 2 * Mathf.PI / unitsInRing;
                float x = Mathf.Cos(angle) * radius;
                float z = Mathf.Sin(angle) * radius;
                position = new Vector3(x, 0.5f, z);
                unit.SetTarget(position);
            }
            ringList.Add(list);
        }

        StartCoroutine(MoveUnits());
    }

    private IEnumerator MoveUnits()
    {
        float tick = 2;
        while (true)
        {
            yield return new WaitForSeconds(2.0f);
            for (int i = 0; i < rings; i++)
            {
                float radius = startRadius + i * ringSpacing;
                List<Unit> list = ringList[i];
                int unitsInRing = list.Count;
                for (int j = 0; j < unitsInRing; j++)
                {
                    float angle = (tick + j) * 2 * Mathf.PI / unitsInRing;
                    float x = Mathf.Cos(angle) * radius;
                    float z = Mathf.Sin(angle) * radius;
                    Vector3 position = new Vector3(x, 0.5f, z);
                    list[j].SetTarget(position);
                }
            }
            tick++;
        }
    }
}
