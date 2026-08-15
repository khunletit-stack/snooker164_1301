using System;
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
    
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Setcolorandpoint(Ballcolor col)
    {
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
                rb.material.color = Color.brown;
                break;
            case Ballcolor.Blue:
                point = 5;
                rb.material.color = Color.blue;
                break;
            case Ballcolor.Pink:
                point = 6;
                rb.material.color = Color.pink;
                break;
            case Ballcolor.Black:
                point = 7;
                rb.material.color = Color.black ;
                break;
        }
    }
}
