using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class NPC : MonoBehaviour {

    public string id;
    public Direction direction;
    public LayerMask layerMask;
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right,
    }

    [HideInInspector]public List<string> dialogue;
    private Vector2 vDirection;

    void Awake()
    {
        //Cargamos el diálogo
        dialogue = CSVReader.Instance.getDialogue(id);
        
    }

	void Start () {

        chooseRayDirection();
	}
	
	void Update () {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, vDirection, 1.0f,layerMask);
        //Debug.DrawRay(transform.position, vDirection, Color.red);
        if(hit && Input.GetKeyDown(KeyCode.T))
        {
            StartCoroutine(actionNPC());
        }
    }

    public abstract IEnumerator actionNPC();

    void chooseRayDirection()
    {
        switch (direction)
        {
            case Direction.Up:
                vDirection = Vector2.up;
                break;
            case Direction.Down:
                vDirection = Vector2.down;
                break;
            case Direction.Left:
                vDirection = Vector2.left;
                break;
            case Direction.Right:
                vDirection = Vector2.right;
                break;
        }
    }
}
