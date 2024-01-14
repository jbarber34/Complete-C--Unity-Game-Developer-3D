using UnityEngine;

[CreateAssetMenu(fileName = "FloatSO", menuName = "ScriptableObjects/FloatSO", order = 1)]
public class FloatSO : ScriptableObject
{
    [SerializeField]
    private float _value;
    public float Value
    {
        get { return _value; }
        set { _value = value; }
    }

}
