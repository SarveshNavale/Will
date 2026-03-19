
using UnityEngine;
using UnityEngine.U2D;

public class TerrainCreator : MonoBehaviour
{
    public SpriteShapeController shape;
    public int scale = 1000;
    public int numOfPoints = 150;
    
    void Start()
    {
        shape = GetComponent<SpriteShapeController>();
        float distanceBwtnpoints = (float)scale/numOfPoints;
        shape.spline.SetPosition(index: 2, shape.spline.GetPosition(index: 2) + Vector3.right * 100);
        shape.spline.SetPosition(index: 3, shape.spline.GetPosition(index: 3) + Vector3.right * 100);

        for (int i = 0; i < 150; i++)
        {
            float xPos = shape.spline.GetPosition(index: i + 1).x + distanceBwtnpoints;
            shape.spline.InsertPointAt(index: i + 2, new Vector3(xPos,y:30*Mathf.PerlinNoise(x:i*Random.Range(5.0f,15.0f),y:0)));
        }

        for (int i = 0; i < 152; i++)
        {
            shape.spline.SetTangentMode(i, ShapeTangentMode.Continuous);
            shape.spline.SetLeftTangent(i, new Vector3(x: -5, y: 0, z: 0));
            shape.spline.SetRightTangent(i, tangent: new Vector3(x: 5, y: 0, z: 0));
        }
    }
}
