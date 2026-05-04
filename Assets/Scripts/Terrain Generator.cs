using UnityEngine;
using UnityEngine.U2D; 

public class TerrainGenerator : MonoBehaviour
{   

    public SpriteShapeController Terrain;
    SpriteShapeController chunk;
    public SpriteShapeController[] c;
    int y=1;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //SpawnThreeChunks();
        spawnTesting();
    }
    void spawnTesting()
    {   Vector3 spawnPos = Vector3.zero; 
        for (int i = 0; i < c.Length; i++)
        {
            // Instantiate chunk at current position
            SpriteShapeController newChunk = Instantiate(
                c[i],
                spawnPos,
                Quaternion.identity
                
            );

            spawnPos = new Vector3(spawnPos.x+61,spawnPos.y-7, 0);
        }
    }



    void SpawnThreeChunks()
    {
        chunk = Instantiate(Terrain, new Vector3(0,0,0), Quaternion.identity);
        ExtendPoints();

    }
    void ExtendPoints()
    {
        var spline = chunk.spline;
        
        int totalToSpawn = 10,i;

        // extend first
        Vector3 PointA = spline.GetPosition(1);
        spline.SetPosition(1, new Vector3(31, y, 0));

        //insert points
        for(i=1; i<=totalToSpawn; i++)
        {
            spline.InsertPointAt(i, new Vector3(3 * i, 1, 0));
           
        }

        //set position of first
        spline.RemovePointAt(i++);
        Vector3 PointB = spline.GetPosition(0);
        spline.SetPosition(0,new Vector3(0, y,0));



    }

}
