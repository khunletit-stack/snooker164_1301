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

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(point);
        Gamemanager.instance.Playerscore += point;
        Destroy(gameObject);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
