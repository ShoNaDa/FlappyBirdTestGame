using UnityEngine;

public class Script : MonoBehaviour
{
    private interface IMovable
    {
        void Move(GameObject objMove, Vector3 course, float moveSpeed);
    }

    public class Bird : IMovable
    {
        public Bird(float _moveSpeed)
        {
            if (_moveSpeed >= 0)
                MoveSpeed = _moveSpeed;
            else
                MoveSpeed = 0;
        }

        public float MoveSpeed { get; set; }
        public string Name => "Sphere_bird";
        public float Drag => 4;

        public void Move(GameObject gameObject, Vector3 course, float moveSpeed)
        {
            gameObject.transform.Translate(course * moveSpeed);
        }

        public void Fly(GameObject gameObject, float moveSpeed)
        {
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.up * moveSpeed;
        }
    }

    public class Camera : IMovable
    {
        public string Name { get { return "MainCamera"; } }

        public void Move(GameObject gameObject, Vector3 course, float moveSpeed)
        {
            gameObject.transform.Translate(course * moveSpeed);
        }
    }


    public Bird bird;
    public Camera cam;
    public GameObject Sphere_bird, MainCam;

    // Start is called before the first frame update
    void Start()
    {
        bird = new Bird(0.07f);
        cam = new Camera();

        Sphere_bird = GameObject.FindWithTag(bird.Name);
        Sphere_bird.GetComponent<Rigidbody>().drag = bird.Drag;

        MainCam = GameObject.FindWithTag(cam.Name);

        Sphere_bird.GetComponent<SphereCollider>().isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        //двигаем птицу и камеру вправо
        bird.Move(Sphere_bird, Vector3.right, bird.MoveSpeed);
        cam.Move(MainCam, Vector3.right, bird.MoveSpeed);

        //нажатие ЛКМ
        if (Input.GetMouseButtonDown(0))
        {
            bird.Fly(Sphere_bird, 8);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // other - объект, с которым произошло столкновение
        bird.MoveSpeed = 0;
        Sphere_bird.GetComponent<Rigidbody>().drag = Mathf.Infinity;

        Debug.Log($"Game over. {other.name}. Score - {CreateColumns.score}");
    }
}
