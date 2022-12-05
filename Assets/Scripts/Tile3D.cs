using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tile3D
{
    /*protected float tileWidth;
    protected float tileLength;

    public Tile3D(float width, float length)
    {
        tileWidth = width;
        tileLength = length;
    }*/

    public abstract void Draw(float posX, float posY, float posZ, Material material);
}
