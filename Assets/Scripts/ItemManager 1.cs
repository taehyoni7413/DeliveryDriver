using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager1 : MonoBehaviour
{
    public Coordinate[] Coordinates =
     {
        new Coordinate(-25,10),
        new Coordinate(-20,10),
        
        new Coordinate(-10,10),
        new Coordinate(-5,10),
        new Coordinate(0,10),
        new Coordinate(5,10),

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
