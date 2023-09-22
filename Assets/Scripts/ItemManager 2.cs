using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager2 : MonoBehaviour
{
    public Coordinate[] Coordinates =
     {
        new Coordinate(-16,13),
        new Coordinate(-16,23),
        new Coordinate(54,23),
        new Coordinate(54,12),
        new Coordinate(43,10),
        new Coordinate(24,10),
        new Coordinate(13,10),
        new Coordinate(13,10),
        new Coordinate(13,26),
        new Coordinate(-1,26),
        new Coordinate(24,26),
        new Coordinate(38,26)
    };
    public GameObject[] ItemPrefabs = new GameObject[3];


    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject itemPrefab = ItemPrefabs[Random.Range(0, ItemPrefabs.Length)];
            Vector2 itemPosition = Coordinates[Random.Range(0, Coordinates.Length)].GetPos();
            SpawnItem(itemPrefab, itemPosition);
        }
    }
    public void SpawnItem(GameObject itemPrefab, Vector2 _position)
    {
        GameObject item = Instantiate(itemPrefab);
        item.transform.position = _position;
    }
    public struct Coordinate
    {
        public int x;
        public int y;
        public Coordinate(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public Vector2 GetPos()
        {
            return new Vector2(x, y);
        }

    }
}
