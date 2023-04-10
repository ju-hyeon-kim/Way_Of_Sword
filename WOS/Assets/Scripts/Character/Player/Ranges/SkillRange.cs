using UnityEngine;

public class SkillRange : MonoBehaviour
{
    public void RangeSetting(float i)
    {
        transform.localScale = new Vector3(i, 0.01f, i);
    }
}
