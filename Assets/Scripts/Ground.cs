using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : Tile3D
{
    //public Material material;

    Mesh plane;

    public Ground(float width, float length)// : base(width, length)
    {
        Vector3[] vertexs;
        int[] triangles;
        Vector2[] uvs;

        plane = new Mesh();

        vertexs = new Vector3[4];

        vertexs[0] = new Vector3(-width / 2, 0, -length / 2);
        vertexs[1] = new Vector3(width / 2, 0, -length / 2);
        vertexs[2] = new Vector3(width / 2, 0, length / 2);
        vertexs[3] = new Vector3(-width / 2, 0, length / 2);

        plane.vertices = vertexs;

        triangles = new int[2 * 3];

        triangles[0] = 2;
        triangles[1] = 1;
        triangles[2] = 0;
        triangles[3] = 3;
        triangles[4] = 2;
        triangles[5] = 0;

        plane.triangles = triangles;

        uvs = new Vector2[4];

        uvs[0] = new Vector2(0, 0);
        uvs[1] = new Vector2(1, 0);
        uvs[2] = new Vector2(1, 1);
        uvs[3] = new Vector2(0, 1);

        plane.uv = uvs;

        plane.RecalculateNormals();
        plane.RecalculateBounds();
    }

    public override void Draw(float posX, float posY, float posZ, Material material)
    {
        Graphics.DrawMesh(plane, new Vector3(posX, posY, posZ), Quaternion.identity, material, 0);
    }

}
