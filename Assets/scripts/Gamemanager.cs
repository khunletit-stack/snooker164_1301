using UnityEngine;
using UnityEngine.InputSystem;

public class Gamemanager : MonoBehaviour
{
    [SerializeField]
    private int playerscore;

    public int Playerscore
    {
        get { return playerscore; }
        set { playerscore = value; }
    }

    [SerializeField]
    private GameObject[] ballposition;

    [SerializeField]
    private GameObject ballPrefab;

    [SerializeField]
    private GameObject cueBall;

    [SerializeField]
    private float xInput = 0f;

    public static Gamemanager instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        SetBall(Ballcolor.Red, 1);
        SetBall(Ballcolor.Yellow, 2);
        SetBall(Ballcolor.Green, 3);
        SetBall(Ballcolor.Brown, 4);
        SetBall(Ballcolor.Blue, 5);
        SetBall(Ballcolor.Pink, 6);
        SetBall(Ballcolor.Black, 7);
    }

    private void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            ShootBall();
        }

        if (Keyboard.current.aKey.isPressed ||
            Keyboard.current.leftArrowKey.isPressed)
        {
            xInput = -0.1f;
        }
        else if (Keyboard.current.dKey.isPressed ||
                 Keyboard.current.rightArrowKey.isPressed)
        {
            xInput = 0.1f;
        }
        else
        {
            xInput = 0f;
        }

        RotateBall();
    }

    private void SetBall(Ballcolor col, int i)
    {
        GameObject obj = Instantiate(
            ballPrefab,
            ballposition[i].transform.position,
            Quaternion.identity
        );

        ball b = obj.GetComponent<ball>();
        b.Setcolorandpoint(col);
    }

    private void ShootBall()
    {
        if (cueBall == null)
            return;

        Rigidbody rb = cueBall.GetComponent<Rigidbody>();

        if (rb == null)
            return;

        rb.AddRelativeForce(
            Vector3.forward * 50f,
            ForceMode.Impulse
        );
    }

    private void RotateBall()
    {
        if (cueBall != null)
        {
            cueBall.transform.Rotate(
                0f,
                xInput,
                0f
            );
        }
    }

    private void StopBall()
    {
        if (cueBall == null)
            return;

        Rigidbody rb = cueBall.GetComponent<Rigidbody>();

        if (rb == null)
            return;

        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        cueBall.transform.eulerAngles = Vector3.zero;
        
    }
}