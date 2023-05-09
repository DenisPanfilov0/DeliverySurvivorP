using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private HeroController _heroController;
    private bool isFacingRight = true; // flag for character direction

    private void Start()
    {
        _heroController = FindObjectOfType<HeroController>();

    }

    void FixedUpdate()
    {
        // _heroController = FindObjectOfType<HeroController>();
        //_speed = _heroController.CurrentSpeed;

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Move the character in the direction of arrow keys or WASD keys
        Vector3 direction = new Vector3(horizontal, vertical, 0f);
        transform.position += direction * _heroController.CurrentSpeed * Time.deltaTime;
        // transform.position += direction * _speed * Time.deltaTime;
        
        if ((horizontal > 0 && !isFacingRight) || (horizontal < 0 && isFacingRight))
        {
            isFacingRight = !isFacingRight;
            transform.Rotate(0f, 180f, 0f);
        }
    }

    // public void ChangeSpeedh(float _changeSpeed)
    // {
    //     _currentspeed /= _changeSpeed / 100 + 1;
    // }
    //
    // public void ReturnSpeed()
    // {
    //     _currentspeed = _startSpeed;
    // }
}
