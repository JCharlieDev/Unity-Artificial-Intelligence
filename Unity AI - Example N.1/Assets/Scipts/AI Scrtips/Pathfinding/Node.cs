using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : IComparable
{
    private Node previous = null;

    private int distance = 0;
    private int heuristic = 0;
    private int score = 0;
    private int x;
    private int y;
    private int type;   //  0 = space, 1 = obstacle, 2 = path

    public int Heuristic { get => heuristic; set => heuristic = value; }
    public int Distance { get => distance; set => distance = value; }
    public int Score { get => score; set => score = value; }
    public int X { get => x; set => x = value; }
    public int Y { get => y; set => y = value; }
    public Node Previous { get => previous; set => previous = value; }
    public int Type { get => type; set => type = value; }

    public Node (int pointX, int pointY, int pointType, Node pointObjective)
    {
        x = pointX;
        y = pointY;
        type = pointType;

        //  Heuristic calculation with manhattan distance.
        if (pointObjective != null)
        {
            heuristic = Math.Abs(x - pointObjective.X) + Math.Abs(y - pointObjective.Y);
        }
    }

    public void CalculateCost()
    {
        if (previous == null)
        {
            distance = 0;
        }
        else
        {
            distance = previous.Distance + 1;
        }

        score = distance + heuristic;
    }

    int IComparable.CompareTo(object obj)
    {
        int r = 0;

        Node temp = (Node)obj;

        if (score > temp.score)
        {
            r = 1;
        }

        if (score < temp.score)
        {
            r = -1;
        }

        return r;
    }

    public override string ToString()
    {
        return string.Format($"{x}, {y}, {type}");
    }

}
