using Godot;
using System;

public partial class CharacterScript : CharacterBody2D
{
	public int gravity = 3000;   //ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();
	public int wspeed { get; set; } = 850;
	public int jumpvelocity { get; set; } = 1200;
	public bool canJump = false;
	
	
	private Sprite2D _idleSprite;
	private Sprite2D _rightSprite;
	private Sprite2D _jumpSprite;
	private Timer _CoyoteTime;
	
	public override void _Ready()
	{
		// get sprite references
		_idleSprite = GetNode<Sprite2D>("IdleSprite");
		_rightSprite = GetNode<Sprite2D>("RightSprite");
		_jumpSprite = GetNode<Sprite2D>("JumpSprite");
		_CoyoteTime = GetNode<Timer>("CoyoteTime");
	}
	
	public override void _PhysicsProcess(double delta)
	{
		var velocity = Velocity;
				
		if (!IsOnFloor()){ 
			if(canJump){
				_CoyoteTime.Start();
			}
			if(Input.IsKeyPressed(Key.Space) && !_CoyoteTime.IsStopped() && canJump){
				canJump = false;
				velocity.Y = -jumpvelocity; 
			}
			else{
				velocity.Y += (float)delta * gravity; 
			}
		}
		else{
			canJump = true;
			if(Input.IsKeyPressed(Key.Space)){
				velocity.Y = -jumpvelocity; 
			}
			//velocity.Y = -jumpvelocity; 
		}	/*	
		if (!IsOnFloor())
			{ velocity.Y += (float)delta * gravity; }

		if (Input.IsKeyPressed(Key.Space) && IsOnFloor())
			{ velocity.Y = -jumpvelocity; }*/
			
			
		if (Input.IsActionPressed("move_right")){ 
			velocity.X = wspeed; 
		}
		else if (Input.IsActionPressed("move_left")){ 
			velocity.X = -wspeed;
		}	
		else { 
			velocity.X = 0; 
		}
			
		_UpdateSpriteRenderer(velocity.X,velocity.Y);
				
		Velocity = velocity;
		MoveAndSlide();
	}
	private void _UpdateSpriteRenderer(float velX, float velY) {
		bool walking = velX != 0;
		bool jumping = velY < 0;
		bool falling = velY >= 0;
		
		_idleSprite.Visible = !walking  && falling;
		_rightSprite.Visible = walking;
		_jumpSprite.Visible = !walking && jumping;
		
		if (walking) {
			//_rightSprite.Play(); //This is for when we want to make a walk cycle animation
			_rightSprite.FlipH = velX < 0;
		}
	}	
}

