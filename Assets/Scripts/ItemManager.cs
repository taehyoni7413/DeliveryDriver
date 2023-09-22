using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
  
    public Coordinate[] Coordinates =
    {
        new Coordinate(-36,2),
        new Coordinate(17,2),
        new Coordinate(-9,10),
        new Coordinate(-9,-6),
        new Coordinate(14,-5),
        new Coordinate(14,9),
        new Coordinate(-32,9),

    };
    public GameObject[] ItemPrefabs = new GameObject[3];
 

    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject itemPrefab = ItemPrefabs[Random.Range(0, ItemPrefabs.Length)];
            Vector2 itemPosition = Coordinates[Random.Range(0,Coordinates.Length)].GetPos();
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
        public Coordinate(int x , int y)
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
