using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    [SerializeField]
    private int playerscore;
    public int Playerscore { get { return playerscore; } set { playerscore = value; } }
    

    [SerializeField]
    private GameObject[] ballposition;

    [SerializeField] 
    private GameObject ballPrefab; 

    public static Gamemanager instance;


    void Awake()
    {
        instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     private void SetBall(Ballcolor col, int i)
    {
         GameObject obj  = Instantiate(ballPrefab,
             ballposition[i].transform.position,
             Quaternion.identity);
        ball b = obj.GetComponent<ball>();
        b.Setcolorandpoint(col);

    }
}
