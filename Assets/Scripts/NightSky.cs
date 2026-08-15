using UnityEngine;

public class NightSky : MonoBehaviour
{
    [SerializeField] private SpriteRenderer NightSkyImage;
    public float RotationSpeed  = 1f;
    public float GameMultipler = 1f;

    // Update is called once per frame
    void Update()
    {
        NightSkyImage.transform.Rotate( 0f, 0f, -RotationSpeed*Time.deltaTime*GameMultipler,Space.Self);
    }
}
