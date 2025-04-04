using System;
using Gameplay.Player;
using UnityEngine;
using Zenject;

public class Enemy : MonoBehaviour
{
    [Inject]
    private Player _player;

}