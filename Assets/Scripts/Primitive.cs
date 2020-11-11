using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Creates a primitive object with a rigid body and mesh collider
public class Primitive : MonoBehaviour
{
    public float width;
    public float height;
    public bool staticObj = false;

    Rigidbody2D rBody;

    // Start is called before the first frame update
    void Start()
    {
        // Add a mesh collider
        BoxCollider2D boxCollider = gameObject.AddComponent<BoxCollider2D>();
        //Vector2 size = meshCollider.size;
        boxCollider.size = new Vector2(width,height);

        //Debug.Log("Box size: " + size);

        // Add a rigid body
        rBody = gameObject.AddComponent<Rigidbody2D>();
        Vector2 pos = rBody.position;
        
        if(staticObj)
            rBody.constraints = RigidbodyConstraints2D.FreezeAll;

        // Create the Mesh
        MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
        meshRenderer.sharedMaterial = new Material(Shader.Find("Standard"));
        
        MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();

        Mesh mesh = new Mesh();
        
        Vector3[] vertices = new Vector3[4]
        {
            new Vector3(0,0,0),
            new Vector3(width, 0, 0),
            new Vector3(0, height, 0),
            new Vector3(width, height, 0)
        };
        mesh.vertices = vertices;

        int[] tris = new int[6]
        {
            // lower left triangle
            0, 2, 1,
            // upper right triangle
            2, 3, 1
        };
        mesh.triangles = tris;

        Vector3[] normals = new Vector3[4]
        {
            -Vector3.forward,
            -Vector3.forward,
            -Vector3.forward,
            -Vector3.forward
        };
        mesh.normals = normals;

        Vector2[] uv = new Vector2[4]
        {
            new Vector2(0,0),
            new Vector2(1,0),
            new Vector2(0,1),
            new Vector2(1,1),
        };
        mesh.uv = uv;

        meshFilter.mesh = mesh;

        Collider2D[] results = new Collider2D[5];

        Debug.Log("Colliders attached to the rigid body: " + rBody.GetAttachedColliders(results));
    }
}
