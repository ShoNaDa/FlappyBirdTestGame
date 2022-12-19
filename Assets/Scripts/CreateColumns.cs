using UnityEngine;

public class CreateColumns : MonoBehaviour
{
    private float positionZ = -10;
    public static int score = 0;

    public GameObject upColumn, downColumn, Sphere_bird;

    void Start()
    {
        Sphere_bird = GameObject.FindWithTag("Sphere_bird");
    }

    void Update()
    {
        if (Sphere_bird.transform.position.z < positionZ)
        {
            positionZ += -10;
            score++;

            GameObject upCube = Instantiate(upColumn, new Vector3(0, 4.6f, positionZ), Quaternion.Euler(0, 0, 180f)).gameObject;
            upCube.transform.localScale = new Vector3(1, 1.7f, 0.5f);
            Destroy(GameObject.Find("UpCube(Clone)"), 1.3f);

            GameObject downCube = Instantiate(downColumn, new Vector3(0, 1.25f, positionZ), Quaternion.Euler(0, 0, 0)).gameObject;
            downCube.transform.localScale = new Vector3(1, 1.9f, 0.5f);
            Destroy(GameObject.Find("DawnCube(Clone)"), 1.3f);
        }
    }
}
