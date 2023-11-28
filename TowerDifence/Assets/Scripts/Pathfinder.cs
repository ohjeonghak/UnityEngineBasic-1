using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    public enum Option
    {
        DFS,
        BFS,
    }
    public Option option;
    public Vector2 destination;
    public List<Vector2> path;

    private void Start()
    {
        TryGetPath();
    }

    public bool TryGetPath()
    {
        bool result = false;
        switch (option) 
        {
            case Option.DFS:
                result = TryGetDFSPath(out path);
                break;
            case Option.BFS:
                result = TryGetBFSPath(out path);
                break;
            default:
                break;

        }
        return result;
    }

    public bool TryGetDFSPath(out List<Vector2> path)
    {
        Map.Node[,] map = Map.instace.nodes;
        bool[,] visited = new bool[map.GetLength(0), map.GetLength(1)]; // 방문 확인용 (지나온 경로는 다시 탐색하면 안됨)
        Stack<Coord> stack = new Stack<Coord>(); // 다음 탐색 대상 스택
        List<Pair> pairs = new List<Pair>(); // 경로 역추적을 위한 경로쌍
        Coord start = Map.instace.VectorToCoord(transform.position);
        Coord end = Map.instace.VectorToCoord(destination);
        stack.Push(start);
        int[,] dir = new int[2, 4]
        {
            //우, 좌, 상. 하
            { 0,  0,  1, -1}, // Y
            { 1, -1,  0,  0} // X
        };

        while (stack.Count > 0)
        {
            Coord current = stack.Pop(); // 스택 제일 위에꺼 꺼내서 탐색
            visited[current.y, current.x] = true; // 방문 완료

            //탐색완료
            if (current == end)
            {
                path = BacktrackPath(start, end, pairs);
                return true;
            }
            else
            {
                for (int i = dir.GetLength(1) - 1; i >= 0; i--)
                {
                    Coord next = current + new Coord(dir[1, i], dir[0, i]);

                    // 맵의 범위 초과하는지
                    if (next.x < 0 || next.x >= map.GetLength(1) ||
                        next.y < 0 || next.y >= map.GetLength(0))
                        continue;

                    // 이미 방문한 경로체크
                    if (visited[next.y, next.x])
                        continue;

                    // 지나갈 수 있는 방향체크
                    if (((int)map[current.y, current.x].mapNode.directionMask & (1 << i)) == 0)
                        continue;

                    stack.Push(next);
                    pairs.Add(new Pair(current, next));
                }
            }
        }

        path = null;
        return false;
    }

    public bool TryGetBFSPath(out List<Vector2> path)
    {
        Map.Node[,] map = Map.instace.nodes;
        bool[,] visited = new bool[map.GetLength(0), map.GetLength(1)]; // 방문 확인용 (지나온 경로는 다시 탐색하면 안됨)
        Queue<Coord> queue = new Queue<Coord>(); // 다음 탐색 대상 스택
        List<Pair> pairs = new List<Pair>(); // 경로 역추적을 위한 경로쌍
        Coord start = Map.instace.VectorToCoord(transform.position);
        Coord end = Map.instace.VectorToCoord(destination);
        queue.Enqueue(start);
        int[,] dir = new int[2, 4]
        {
            //우, 좌, 상. 하
            { 0,  0,  1, -1}, // Y
            { 1, -1,  0,  0} // X
        };

        while (queue.Count > 0)
        {
            Coord current = queue.Dequeue(); // 스택 제일 위에꺼 꺼내서 탐색
            visited[current.y, current.x] = true; // 방문 완료

            //탐색완료
            if (current == end)
            {
                path = BacktrackPath(start, end, pairs);
                return true;
            }
            else
            {
                for (int i = 0; i < map.GetLength(1); i++)
                {
                    Coord next = current + new Coord(dir[1, i], dir[0, i]);

                    // 맵의 범위 초과하는지
                    if (next.x < 0 || next.x >= map.GetLength(1) ||
                        next.y < 0 || next.y >= map.GetLength(0))
                        continue;

                    // 이미 방문한 경로체크
                    if (visited[next.y, next.x])
                        continue;

                    // 지나갈 수 있는 방향체크
                    if (((int)map[current.y, current.x].mapNode.directionMask & (1 << i)) == 0)
                        continue;

                    queue.Enqueue(next);
                    pairs.Add(new Pair(current, next));
                }
            }
        }

        path = null;
        return false;
    }

    private List<Vector2> BacktrackPath(Coord start, Coord end, List<Pair> pairs)
    {
        List<Vector2> path = new List<Vector2>();
       
        Coord coord = end;
        for (int i = pairs.Count - 1; i >= 0; i--)
        {
            if (pairs[i].next == coord)
            {
                path.Add(Map.instace.CoordToVector(coord));
                coord = pairs[i].prev;
            }
            pairs.RemoveAt(i);
        }

        if (coord != start)
            throw new System.Exception($"[Pathfinder] : 경로 역추적 실패..경로에 문제가 있음");
       
        path.Add(Map.instace.CoordToVector(coord));
        path.Reverse();
        return path;
    }
}