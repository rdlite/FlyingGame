using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public static bool IsAcceleration { get; private set; }

    [SerializeField] private string _horizntalAxis;

    public Vector3 GetInput()
    {
        return new Vector3(Input.GetAxis(_horizntalAxis), 0f, 0f);
    }

    public void SetIsBoost()
    {
        IsAcceleration = Input.GetKey(KeyCode.Space);
    }
}
