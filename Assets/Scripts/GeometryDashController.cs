using UnityEngine;

public class GeometryDashController : PlatformerMovement
{
  public override void Update()
  {
    if (!_playerLife.isAlive) return;
    _horizontal = 1;

    if (IsGrounded())
    {
      _jumps = 0;
    }
        
    if (_jumps < 1 && Input.GetKeyDown(KeyCode.J))
    {
      _jumpToConsume = true;
    }

    FlipPlayer();
    UpdateAnimation();
  }

  protected override void UpdateAnimation()
  {
    base.UpdateAnimation();
    _animator.SetBool("isRunning", false);
  }
}
