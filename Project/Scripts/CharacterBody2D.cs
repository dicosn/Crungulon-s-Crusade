using Godot;
using System;


public partial class CharacterBody2D : Godot.CharacterBody2D
{
	public int gravity = 3000;   //ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();
	public int wspeed { get; set; } = 850;
	public int jumpvelocity { get; set; } = 1300;
	public int accel = 50;
	
	
	private Sprite2D _idleSprite;
	private Sprite2D _rightSprite;
	private Sprite2D _leftSprite;
	private Sprite2D _jumpSprite;
	private float air_time = 0.0f;
	private float ct_thresh = 0.067f;
	
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
		
		//air behavior
		if (!IsOnFloor()){ 
			//time spent airborn
			air_time += (float)delta;
			//jump while airtime below the coyote time threshhold
			if(Input.IsKeyPressed(Key.Space) && air_time <= ct_thresh){
				velocity.Y = -jumpvelocity; 
			}
			else{//fall normal style
				velocity.Y += (float)delta * gravity; 
			}
		}
		else{//dont fall, but jump when necessary
			air_time = 0;
			if(Input.IsKeyPressed(Key.Space)){
				velocity.Y = -jumpvelocity; 
			}
		}		
		
		//horizontal motion
		if (Input.IsActionPressed("move_right")){ 
			//player initially has 0 velocity,
			//makes it so it will reach max velocity after a few frames
			velocity.X = Math.Min(velocity.X + accel,wspeed); 
		}//mirrored rightward motion
		else if (Input.IsActionPressed("move_left")){ 
			velocity.X = Math.Max(velocity.X - accel,-wspeed); ;
		}	
		
		else { 
			velocity.X = 0; 
		}
			
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
	/*private void _on_coyote_time_timeout()
	{
		canJump = false;
	}*/
}
