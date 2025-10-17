using UnityEngine;

public class GameManager : MonoBehaviour
{
    public void FollowUpdate(Transform follow, Transform target, float followSpeed = 5.0f)
    {
        var delta = target.position - follow.transform.position;
        follow.transform.position += delta * Time.deltaTime * followSpeed;
    }
}
