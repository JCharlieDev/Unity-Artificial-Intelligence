using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField] public GameObject jugador;
    [SerializeField] public GameObject personaje;
    [SerializeField] public GameObject obstacle;

    private int[,] charMap =
    {
        {1, 1, 0, 0, 0, 0, 0, 0, 1, 0},
        {1, 1, 0, 0, 0, 0, 0, 0, 1, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {1, 0, 0, 1, 1, 1, 1, 1, 1, 0},
        {0, 0, 0, 0, 0, 1, 0, 1, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 1, 0, 0},
        {0, 0, 1, 0, 0, 0, 0, 1, 0, 0},
        {0, 1, 1, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 1, 0, 0, 0, 0, 1, 1, 1},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
    };

    private Node[,] nodeMap;
    private Node objective;

    public List<Node> route = new List<Node>();
    private List<Node> open = new List<Node>();
    private List<Node> closed = new List<Node>();

    public int startX = 5;
    public int startY = 4;
    private int height;
    private int width;
    // Start is called before the first frame update
    void Start()
    {
        width = charMap.GetLength(0);
        height = charMap.GetLength(1);

        nodeMap = new Node[width, height];

        //  We create map's nodes.

        int row = 0;
        int column = 0;
        int jugadorX = (int)jugador.transform.position.x;
        int jugadorY = (int)jugador.transform.position.z;
        startX = (int)personaje.transform.position.x;
        startY = (int)personaje.transform.position.z;

        objective = new Node(jugadorX, jugadorY, 0, null);
        Debug.Log($"{objective}, {startX}, {startY}");

        for (column = 0;  column < height; column++)
        {
            for (row = 0;  row < width; row++)
            {
                nodeMap[row, column] = new Node(row, column, charMap[row, column], objective);
            }
        }

        nodeMap[jugadorX, jugadorY] = objective;

        row = 0;
        column = 0;

        for (row = 0;  row < width; row++)
        {
            for (column = 0;  column < width; column++)
            {
                if (nodeMap[row,column].Type == 1)
                {
                    Instantiate(obstacle, new Vector3(row + 0.5f, 0.5f, column + 0.5f), Quaternion.identity);
                }
            }
        }

        //  Algorithm call.
        AStart();

        //  We get the route.
        ShowPath();
    }

    private void ShowPath()
    {
        Node job = objective;
        Debug.Log("In ShowPath()");

        while (job.Previous != null)
        {
            Debug.Log($"{job.X}, {job.Y}");
            route.Add(job);
            nodeMap[job.X, job.Y].Type = 2;
            job = job.Previous;
        }

        route.Reverse();
    }

    private void AStart()
    {
        Node actual = null;

        //  Add node to first to the list.
        open.Add(nodeMap[startX, startY]);

        //  While we have open nodes on our list.
        while (open.Count != 0)
        {
            //  Finds the one with less score.
            open.Sort();
            actual = open[0];

            //  verify if the objetive is the correct one.
            if (actual.X == objective.X && actual.Y == objective.Y)
            {
                Debug.Log("Arrived to objective");
                break;
            }
            else
            {
                open.RemoveAt(0);
                closed.Add(actual);

                for (int row = actual.X - 1; row <= actual.X + 1; row++)
                {
                    for (int column = actual.Y - 1; column <= actual.Y + 1; column++)
                    {
                        if (open.Contains(nodeMap[TypeRow(row), TypeColumn(column)]) == false &&
                            closed.Contains(nodeMap[TypeRow(row), TypeColumn(column)]) == false &&
                            nodeMap[TypeRow(row), TypeColumn(column)].Type != 1)
                        {
                            nodeMap[TypeRow(row), TypeColumn(column)].Previous = actual;
                            nodeMap[TypeRow(row), TypeColumn(column)].CalculateCost();
                        }
                    }
                }
            }
        }
    }

    public Node GetNode(int pointIndex)
    {
        return route[pointIndex];
    }

    public int TypeColumn(int pointColumn)
    {
        if (pointColumn < 0)
        {
            return 0;
        }
        if (pointColumn >= width)
        {
            return width - 1;
        }

        return pointColumn;
    }

    public int TypeRow(int pointRow)
    {
        if (pointRow < 0)
        {
            return 0;
        }
        if (pointRow >= height)
        {
            return height + 1;
        }

        return pointRow;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
