using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyEngine;

public class Canon : Tile3D
{
    Mesh blockBase;
    float h;
    float ubr;

    Mesh sphere;

    private int gridSize;
    private Vector3[] vertices;
    private Vector3[] normals;
    private Vector3[] UVs;

    public Canon(Tilemap3D tileMap, Vector3 position, float height, float upBaseReduction) : base(tileMap, position)
    {
        h = height;
        ubr = upBaseReduction;

        blockBase = MeshDrawer.Trapezoid(tileMap.tileWidth, tileMap.tileLength, h, ubr);
        //sphere = MeshDrawer.Trapezoid(tileMap.tileWidth / 4, tileMap.tileLength / 4, h / 2, ubr);

        sphere = MeshDrawer.Octahedron(0, 1.0f);
    }
    
    public override void Draw(Material material)
    {
        Graphics.DrawMesh(blockBase, position, Quaternion.identity, material, 0);

        Graphics.DrawMesh(sphere, new Vector3(position.x, position.y + h + 1f, position.z), Quaternion.identity, material, 0);
    }
}
