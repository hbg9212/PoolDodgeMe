using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimRotation : MonoBehaviour
{
    [SerializeField] private SpriteRenderer characterRenderer;

    private CharacterController _controller;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    void Start()
    {
        _controller.OnLookEvent += OnAim;
    }

    public void OnAim(Vector2 newAimDirection)
    {
        RotateArm(newAimDirection);
    }

    private void RotateArm(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // 마우스 위치에 따른 캐릭터 스프라이트 랜더러 전환
        if (Mathf.Abs(rotZ) > 90f)
        {
            characterRenderer.transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            characterRenderer.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
