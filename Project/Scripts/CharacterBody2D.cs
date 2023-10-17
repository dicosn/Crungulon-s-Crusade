using Godot;
using System;


public partial class CharacterBody2D : Godot.CharacterBody2D
{
	public float gravity = 3000;   //ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();
	public int wspeed { get; set; } = 800;
	public int jumpvelocity { get; set; } = 1200;
	private Sprite2D _idleSprite;
	private Sprite2D _rightSprite;
	private Sprite2D _leftSprite;
	private Sprite2D _jumpSprite;
	public override void _Ready()
	{
		// get sprite references
		_idleSprite = GetNode<Sprite2D>("IdleSprite");
		_rightSprite = GetNode<Sprite2D>("RightSprite");
		//_leftSprite = GetNode<Sprite2D>("LeftSprite");
		_jumpSprite = GetNode<Sprite2D>("JumpSprite");
	}
	
	public override void _PhysicsProcess(double delta)
	{
		var velocity = Velocity;
		
		if (!IsOnFloor())
			{ velocity.Y += (float)delta * gravity; }
		
		if (Input.IsKeyPressed(Key.Space) && IsOnFloor())
			{ velocity.Y = -jumpvelocity; }

		
		if (Input.IsActionPressed("move_right"))
			{ velocity.X = wspeed; }
			
		else if (Input.IsActionPressed("move_left"))
			{ velocity.X = -wspeed; }	
		
		else 
			{ velocity.X = 0; }
			
		_UpdateSpriteRenderer(velocity.X,velocity.Y);
		//_UpdateSpriteRendererY(velocity.Y);
		
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
