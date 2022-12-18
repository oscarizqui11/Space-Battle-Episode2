using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : Tile3D
{
    Mesh block;

    Mesh sphere;

    public Canon(Tilemap3D tileMap, Vector3 position) : base(tileMap, position)
    {
        float phi = (1.0f + Mathf.Sqrt(5.0f)) * 0.5f; // golden ratio
        float a = 1.0f;
        float b = 1.0f / phi;

        Vector3[] vertexs;
        int[] triangles;
        Vector2[] uvs;

        sphere = new Mesh();

        vertexs = new Vector3[12];

        vertexs[0] = new Vector3(0, b, -a);
        vertexs[1] = new Vector3(b, a, 0);
        vertexs[2] = new Vector3(-b, a, 0);
        vertexs[3] = new Vector3(0, b, a);
        vertexs[4] = new Vector3(0, -b, a);
        vertexs[5] = new Vector3(-a, 0, b);
        vertexs[6] = new Vector3(0, -b, -a);
        vertexs[7] = new Vector3(a, 0, -b);
        vertexs[8] = new Vector3(a, 0, b);
        vertexs[9] = new Vector3(-a, 0, -b);
        vertexs[10] = new Vector3(b, -a, 0);
        vertexs[11] = new Vector3(-b, -a, 0);


        block.vertices = vertexs;

        triangles = new int[6 * 2 * 3];

        triangles[0] = 2;
        triangles[1] = 1;
        triangles[2] = 0;
        triangles[3] = 3;
        triangles[4] = 2;
        triangles[5] = 0;

        triangles[6] = 1;
        triangles[7] = 5;
        triangles[8] = 2;
        triangles[9] = 2;
        triangles[10] = 5;
        triangles[11] = 6;

        triangles[12] = 0;
        triangles[13] = 4;
        triangles[14] = 5;
        triangles[15] = 0;
        triangles[16] = 5;
        triangles[17] = 1;

        triangles[18] = 3;
        triangles[19] = 7;
        triangles[20] = 0;
        triangles[21] = 0;
        triangles[22] = 7;
        triangles[23] = 4;

        triangles[24] = 3;
        triangles[25] = 6;
        triangles[26] = 7;
        triangles[27] = 3;
        triangles[28] = 2;
        triangles[29] = 6;

        triangles[30] = 4;
        triangles[31] = 7;
        triangles[32] = 5;
        triangles[33] = 7;
        triangles[34] = 6;
        triangles[35] = 5;

        block.triangles = triangles;

        uvs = new Vector2[8];

        uvs[0] = new Vector2(0, 0);
        uvs[1] = new Vector2(1, 0);
        uvs[2] = new Vector2(1, 1);
        uvs[3] = new Vector2(0, 1);

        uvs[4] = new Vector2(0, 0);
        uvs[5] = new Vector2(1, 0);
        uvs[6] = new Vector2(1, 1);
        uvs[7] = new Vector2(0, 1);

        block.uv = uvs;

        block.RecalculateNormals();
        block.RecalculateBounds();
    }

    public override void Draw(Material material)
    {
        Graphics.DrawMesh(block, position, Quaternion.identity, material, 0);

        Graphics.DrawMesh(sphere, new Vector3(position.x, position.y + 5, position.z), Quaternion.identity, material, 0);
    }
}
