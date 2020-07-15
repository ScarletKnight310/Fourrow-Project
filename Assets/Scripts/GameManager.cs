using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Player p1 = new Player("Player 1", 'p');
    Player p2 = new Player("Player 2", 'g');
    public GameObject p1_token;
    public GameObject p2_token;

    private bool isP1turn = true;
    public GameBoard board;

    // visuals
    private List<GameObject> tokens;
    private GameObject[] bounds = new GameObject[3];
    private GameObject[] grid = new GameObject[12];

    void Start()
    {
        tokens = new List<GameObject>();
        p1 = new Player("Player 1", 'p');
        p2 = new Player("Player 2", 'g');
        createBounds();
        createGrid();
    }

    void Restart() {

    }

    void Update()
    {
       //if() 
    }

    public void createBounds() {
        //------------------------------- create
        for (int i = 0; i < bounds.Length; i++) {
            bounds[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
            bounds[i].AddComponent<BoxCollider>();
            bounds[i].GetComponent<Renderer>().material.color = new Color(0, 0, 0);
        }
        //------------------------------- position each
        bounds[0].transform.position = new Vector3(-4, 0, 0);
        bounds[1].transform.position = new Vector3(4, 0, 0);
        // bottom
        bounds[2].transform.position = new Vector3(0, -3.5f, 0);
        //--------------------------------- scale
        bounds[0].transform.localScale = new Vector3(1, 8, 1);
        bounds[1].transform.localScale = new Vector3(1, 8, 1);
        // bottom
        bounds[2].transform.localScale = new Vector3(7, 1, 1);
        
    }

    public void createGrid() {
        for (int i = 0; i < grid.Length; i++) {
            grid[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
            grid[i].GetComponent<Renderer>().material.color = new Color(100, 100, 100);
        }
        
        int j = 0;
        // horizontal
        int h = -2;
        while (j < grid.Length / 2) {
            grid[j].transform.position = new Vector3(0, h, 1);
            grid[j].transform.localScale = new Vector3(7, 0.1f, 0.5f);
            h++;
            j++;
        }
        // vertical
        float v = -2.5f;
        while(j < grid.Length) {
            grid[j].transform.position = new Vector3(v, 0, 1);
            grid[j].transform.localScale = new Vector3(0.1f, 8, 0.5f);
            v += 1;
            j++;
        }
    }

    public void SC0()
    {
        tokens.Add(Instantiate(isP1turn ? p1_token : p2_token, new Vector3(-3,5,0), Quaternion.identity));
        setchecker(isP1turn ? p1.token : p2.token, 0);
    }

    public void SC1()
    {
        tokens.Add(Instantiate(isP1turn ? p1_token : p2_token, new Vector3(-2, 5, 0), Quaternion.identity));
        setchecker(isP1turn ? p1.token : p2.token, 1);
    }

    public void SC2()
    {
        tokens.Add(Instantiate(isP1turn ? p1_token : p2_token, new Vector3(-1, 5, 0), Quaternion.identity));
        setchecker(isP1turn ? p1.token : p2.token, 2);
    }

    public void SC3()
    {
        tokens.Add(Instantiate(isP1turn ? p1_token : p2_token, new Vector3(0, 5, 0), Quaternion.identity));
        setchecker(isP1turn ? p1.token : p2.token, 3);
    }

    public void SC4()
    {
        tokens.Add(Instantiate(isP1turn ? p1_token : p2_token, new Vector3(1, 5, 0), Quaternion.identity));
        setchecker(isP1turn ? p1.token : p2.token, 4);
    }

    public void SC5()
    {
        tokens.Add(Instantiate(isP1turn ? p1_token : p2_token, new Vector3(2, 5, 0), Quaternion.identity));
        setchecker(isP1turn ? p1.token : p2.token, 5);
    }

    public void SC6()
    {
        tokens.Add(Instantiate(isP1turn ? p1_token : p2_token, new Vector3(3, 5, 0), Quaternion.identity));
        setchecker(isP1turn ? p1.token : p2.token, 6);
    }

    void setchecker(char token, int loc)
    {
        board.SetChecker(token, loc);
        isP1turn = !isP1turn;
    } 
}
