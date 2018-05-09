using UnityEngine;

public class PointInTime {

    public Vector3 position;
    public Quaternion rotation;
    public int direction;
    public PointInTime(Vector3 pos, Quaternion rot, int dir)
    {
        position = pos;
        rotation = rot;
        direction = dir;
    }
}
