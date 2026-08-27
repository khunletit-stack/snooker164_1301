using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

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

    [SerializeField]
    private GameObject ballLine;

    [SerializeField]
    private GameObject cam;

    [SerializeField]
    private TMP_Text notiText;

    public static Gamemanager instance;

     void Awake()
    {
        instance = this;
    }

   void Start()
    {
        CameraBehindCueBall();

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
        RotateBall();

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        
            ShootBall();
        

        if (Keyboard.current.aKey.isPressed ||
            Keyboard.current.leftArrowKey.isPressed)
        {
            xInput = -0.05f;
        }
        else if (Keyboard.current.dKey.isPressed ||
                 Keyboard.current.rightArrowKey.isPressed)
        
            xInput = 0.05f;
        
        else
        
            xInput = 0f;


       if (Keyboard.current.backspaceKey.wasPressedThisFrame)
            StopBall();

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
        Rigidbody rb = cueBall.GetComponent<Rigidbody>();
        rb.AddRelativeForce(
            Vector3.forward * 50f,
            ForceMode.Impulse);

        ballLine.SetActive(false);
        cam.transform.parent = null;
        cam.transform.position = new Vector3(0f, 30f, -42f);
        cam.transform.eulerAngles = new Vector3(45f, 0f, 0f);
    }

    private void RotateBall()
    {
        if (cueBall != null)
        {
            cueBall.transform.Rotate(new Vector3(0f,xInput,0f));
        }
    }

    private void StopBall()
    {
      
        Rigidbody rb = cueBall.GetComponent<Rigidbody>();


        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        cueBall.transform.eulerAngles = Vector3.zero;

        ballLine.SetActive(true);
        CameraBehindCueBall();

    }

    private void CameraBehindCueBall()
    {
        cam.transform.parent = cueBall.transform;
        cam.transform.position = cueBall.transform.position + new Vector3(0f, 7f, -15f);
        cam.transform.eulerAngles = new Vector3(30f, 0f, 0f);

        //cam.transform.parent = cueBall.transform;
        //cam.transform.position = cueBall.transform.position + new Vector3(0f, 7f, -15f);
        //cam.transform.eulerAngles = new Vector3(30f, 0f, 0f);
    }

    public void ShowScoreText(int n)
    {
        playerscore += n;
        notiText.text = $"Ball Point:{n}\nTotal Score:{playerscore}";
    }
    public void ShowString(string s)
    {
        notiText.text = s;
    }

}