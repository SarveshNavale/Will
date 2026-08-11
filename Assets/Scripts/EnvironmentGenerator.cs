using UnityEngine;
using UnityEngine.U2D;

// [ExecuteInEditMode]
public class EnvironmentGenerator : MonoBehaviour
{
    [SerializeField] private SpriteShapeController _spriteShapeController;

    [SerializeField, Range(3f, 100f)] private int _platformWidth = 50;
    [SerializeField] private float _platformHeight = 10f;
    [SerializeField, Range(1f, 50f)] private float _xDistance = 2f;
    [SerializeField, Range(1f, 50f)] private float _yDistance = 2f;

    [SerializeField] private float _noiseStep = 0.5f;
    [SerializeField, Range(0f, 1f)] private float _tangentSmoothness = 0.5f;

    private Vector3 _lastPos;

    private void OnValidate()
    {
        _spriteShapeController.spline.Clear();

        for (int i =0; i < _platformWidth; i++)
        {
            _lastPos = new Vector3(i * _xDistance, Mathf.PerlinNoise(0, i* _noiseStep)*_yDistance);
            _spriteShapeController.spline.InsertPointAt(i,  _lastPos);

            if(i!=0 && i != _platformWidth - 1)
            {
                _spriteShapeController.spline.SetTangentMode(i, ShapeTangentMode.Continuous);
                _spriteShapeController.spline.SetLeftTangent(i, Vector3.left * _xDistance * _tangentSmoothness);
                _spriteShapeController.spline.SetRightTangent(i, Vector3.right * _xDistance * _tangentSmoothness);
            }
        }

        _spriteShapeController.spline.InsertPointAt(_platformWidth, new Vector3(_lastPos.x, -_platformHeight));
        _spriteShapeController.spline.InsertPointAt(_platformWidth+1, new Vector3(0, -_platformHeight));
    }
}