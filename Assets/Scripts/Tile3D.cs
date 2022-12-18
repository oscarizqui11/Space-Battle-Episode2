using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tile3D
{
    protected Tilemap3D tileMap;
    protected Vector3 position;

    public Tile3D(Tilemap3D tileMap, Vector3 position)
    {
        this.tileMap = tileMap;
        this.position = position;
    }

    public abstract void Draw(Material material);
}
