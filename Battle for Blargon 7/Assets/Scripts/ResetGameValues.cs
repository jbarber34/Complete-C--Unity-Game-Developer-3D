using UnityEngine;

public class ResetGameValues : MonoBehaviour
{
    [SerializeField] private FloatSO scoreSO;

    public void ResetValue()
    {
        scoreSO.Value = 0;
    }
}
