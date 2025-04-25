using Gameplay;
using UnityEngine;

public class ShellPrefabhandler : MonoBehaviour
{
    [SerializeField] private Shell _shellPrefab;
    
    public Shell ShellPrefab => _shellPrefab;
}