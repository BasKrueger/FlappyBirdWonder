using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    [SerializeField]
    private GroundTile tileTemplate;

    [SerializeField]
    private Transform startPoint;
    [SerializeField]
    private Transform endPoint;

    private GroundTile nextTile;

    public void InitialSetUp()
    {
        GenerateNextTile();
        nextTile.GenerateNextTile();
    }

    private void GenerateNextTile()
    {
        nextTile = Instantiate(tileTemplate);
        nextTile.transform.parent = transform.parent;

        nextTile.transform.position += this.endPoint.position - nextTile.startPoint.position;
        nextTile.name = "GroundTile";
    }

    private void Update()
    {
        Vector2 screenPos = Camera.main.WorldToScreenPoint(endPoint.position);

        if(Camera.main.WorldToScreenPoint(endPoint.position).x < 0)
        {
            nextTile.nextTile.GenerateNextTile();
            Destroy(this.gameObject);
        }
    }
}
