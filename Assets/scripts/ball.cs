using UnityEngine;
using UnityEngine.EventSystems;

public enum Ballcolor
{
    White,
    Red,
    Yellow,
    Green,
    Brown,
    Blue,
    Pink,
    Black
}

public class ball : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private int point;
    public int Point {  get { return point; } set { point = value; }  }
    [SerializeField]
    private Ballcolor color;

    [SerializeField]
    private MeshRenderer rb;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(point);

        Gamemanager.instance.Playerscore += point;

        Destroy(gameObject);
    }

    private void Start()
    {
    }

    private void Update()
    {
    }

    public void Setcolorandpoint(Ballcolor col)
    {
        color = col;

        switch (col)
        {
            case Ballcolor.White:
                point = 0;
                rb.material.color = Color.white;
                break;

            case Ballcolor.Red:
                point = 1;
                rb.material.color = Color.red;
                break;

            case Ballcolor.Yellow:
                point = 2;
                rb.material.color = Color.yellow;
                break;

            case Ballcolor.Green:
                point = 3;
                rb.material.color = Color.green;
                break;

            case Ballcolor.Brown:
                point = 4;
                rb.material.color = new Color(0.36f, 0.18f, 0.07f);
                break;

            case Ballcolor.Blue:
                point = 5;
                rb.material.color = Color.blue;
                break;

            case Ballcolor.Pink:
                point = 6;
                rb.material.color = new Color(1f, 0.4f, 0.7f);
                break;

            case Ballcolor.Black:
                point = 7;
                rb.material.color = Color.black;
                break;
        }
    }
}