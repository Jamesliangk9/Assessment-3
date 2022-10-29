using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacStudentController : MonoBehaviour
{
    public KeyCode LastInput;
    public KeyCode CurrentInput;
    public float Speed;
    public float time = 0;
    bool Move = false;
    bool Move2 = false;
    public string Name;
    public Vector2 Pos;
    public Vector2 Pos2;
    public void Correcting()
    {
        Vector2 pos = transform.position;
        float a = Mathf.Ceil(transform.position.x);
        float b = Mathf.Ceil(transform.position.y);
        transform.position = new Vector2(a - 0.5f, b - 0.5f);
    }

    void Update()
    {
        if (!Move)
        {
            time += Time.deltaTime;
        }
        else
        {
            time = 0;
            if (Move2)
            {
                Correcting();
                Move2 = false;
            }
        }
        if (time >=2)
        {
            Move2 = true;
            if(LastInput != null)
            {
                if (LastInput == KeyCode.W)
                {
                    CurrentInput = KeyCode.W;
                }
                if (LastInput == KeyCode.S)
                {
                    CurrentInput = KeyCode.S;
                }
                if (LastInput == KeyCode.A)
                {
                    CurrentInput = KeyCode.A;
                }
                if (LastInput == KeyCode.D)
                {
                    CurrentInput = KeyCode.D;
                }
            }
        }
        MoveWay();
    }
    public void MoveWay()
    {
        if (LastInput == KeyCode.W)
        {
            RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y ), Vector2.up);
            if (hit.collider != null)
                if (hit.collider.tag == "Finish")
                {
                    if (Name == hit.collider.name)
                        if (Vector2.Distance(hit.collider.transform.position, transform.position) > 1f)
                            transform.position = Vector2.Lerp(new Vector2(transform.position.x, transform.position.y), new Vector2(transform.position.x, transform.position.y + 1), Speed * Time.deltaTime);

                    print(hit.transform.name);
                }
        }
        else if (LastInput == KeyCode.S)
        {
            RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y ), Vector2.down);
            if (hit.collider != null)
                if (hit.collider.tag == "Finish")
                {
                    if (Name == hit.collider.name)
                        if (Vector2.Distance(hit.collider.transform.position, transform.position) > 1f)
                            transform.position = Vector2.Lerp(new Vector2(transform.position.x, transform.position.y), new Vector2(transform.position.x, transform.position.y - 1), Speed * Time.deltaTime);
                    print(hit.transform.name);
                }
        }
        else if (LastInput == KeyCode.A)
        {
            RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), Vector2.left);
            if (hit.collider != null)
                if (hit.collider.tag == "Finish")
                {
                    if(Name==hit.collider.name)
                    if (Vector2.Distance(hit.collider.transform.position, transform.position) > 1)
                            transform.position = Vector2.Lerp(new Vector2(transform.position.x, transform.position.y), new Vector2(transform.position.x - 1, transform.position.y), Speed * Time.deltaTime);
                    print(hit.transform.name);
                }
        }
        else if (LastInput == KeyCode.D)
        {
            RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x , transform.position.y), Vector2.right);
            if (hit.collider != null)
                if (hit.collider.tag == "Finish")
                {
                    if (Name == hit.collider.name)
                        if (Vector2.Distance(hit.collider.transform.position, transform.position) > 1)
                            transform.position = Vector2.Lerp(new Vector2(transform.position.x, transform.position.y), new Vector2(transform.position.x + 1, transform.position.y), Speed * Time.deltaTime);
                    print(hit.transform.name);
                }
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y ), Vector2.up);
            if (hit.collider != null)
                if (hit.collider.tag == "Finish")
                {
                    Name = hit.collider.name;
                }
            LastInput = KeyCode.W;
            Move = true;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y ), Vector2.down);
            if (hit.collider != null)
                if (hit.collider.tag == "Finish")
                { Name = hit.collider.name; }
            LastInput = KeyCode.S;
            Move = true;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x , transform.position.y), Vector2.left);
            if (hit.collider != null)
                if (hit.collider.tag == "Finish")
                { Name = hit.collider.name; }
            LastInput = KeyCode.A;
            Move = true;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x , transform.position.y), Vector2.right);
            if (hit.collider != null)
                if (hit.collider.tag == "Finish")
                { Name = hit.collider.name; }
            LastInput = KeyCode.D;
            Move = true;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            Move = false;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            Move = false;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            Move = false;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            Move = false;
        }
    }
}
