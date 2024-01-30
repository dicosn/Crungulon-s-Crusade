using Godot;
using System;

public partial class CharacterScript : CharacterBody2D
{
	[Signal]
	public delegate void HitEventHandler();
	[Export]
	public Label Velocityl;
	[Export]
	public Label Health;
//	[Export]
//	public PackedScene Main_Test { get;set; }
	
	public int jumpvelocity { get; set; } = 1000;	//was 1500
	public int gravity = 7500;   //ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();
	public int wspeed { get; set; } = 1000;
	public int gcap = 1500;
	public int accel = 50;
	
	//stats for display
	public float velocityY = 0.0f;
	public float velocityX = 0.0f;
	
	private Sprite2D _leftSprite;
	private Sprite2D _jumpSprite;
	private Sprite2D _idleSprite;
	private Sprite2D _rightSprite;
	
	private float health = 5;
	
	//coyote time vars
	private float air_time = 0.0f;
	private float ct_thresh = 0.067f;
	private bool stopped_jumping = false;
	
	//jump time vars
	public float jump_time = 0.0f;
	public float jt_thresh = 0.3f;
	
//	public float Health	{
//		get	{	
//			return health;	
//		}
//		set	{
//			health = value;
//			if (health <= 0){
//				QueueFree();}
//		}
//	}
	public override void _Ready(){
		_idleSprite = GetNode<Sprite2D>("IdleSprite");
		_rightSprite = GetNode<Sprite2D>("RightSprite");
		_jumpSprite = GetNode<Sprite2D>("JumpSprite");
	}
	public override void _PhysicsProcess(double delta){
		var velocity = Velocity;
		if(Input.IsKeyPressed(Key.Escape)){
			GetTree().Quit();
			GD.Print("escape");
		}
		
		//if jump button pressed
		if(Input.IsKeyPressed(Key.Space)){
			//and on the floor
			if(IsOnFloor()){
				//then you can jump
				velocity.Y = -jumpvelocity;
				stopped_jumping = false;
			}
			else if(air_time < ct_thresh && stopped_jumping){
				velocity.Y = -jumpvelocity;
				air_time = ct_thresh;
				jump_time = 0f;
				stopped_jumping = false;
			}
		}
		//if holding down jump
		if(Input.IsKeyPressed(Key.Space) && !stopped_jumping){
			//and threshold not reached
			if(jump_time < jt_thresh){
				//keep jumping
				velocity.Y = -(float)jumpvelocity*1.25f;
				jump_time += (float)delta;
			}
		}
		
		if(!Input.IsKeyPressed(Key.Space)){
			jump_time = jt_thresh;
			stopped_jumping = true;
		}
		
		if(IsOnFloor()){
			air_time = 0f;
			jump_time = 0f;
		}
		else{
			velocity.Y += Math.Min(gcap,(float)delta*gravity);
			air_time += (float)delta;
		}
		
		//horizontal motion
		if (Input.IsActionPressed("move_right")){ 
			//player initially has 0 velocity,
			//makes it so it will reach max velocity after a few frames
			velocity.X = Math.Min(velocity.X + accel,wspeed); 
		}	
		//mirrored rightward motion
		else if (Input.IsActionPressed("move_left")){ 
			velocity.X = Math.Max(velocity.X - accel,-wspeed); ;
		}	
		else{ 
			velocity.X = 0; 
		}
			
		_UpdateSpriteRenderer(velocity.X,velocity.Y);
		
		Velocity = velocity;
		velocityY = velocity.Y;
		velocityX = velocity.X;
		Velocityl.Text = $"Velocity X: {velocity.X}, Velocity Y: {velocity.Y}";
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
//	private void OnInputEvent(CharacterBody2D body){
//		Hide(); // Player disappears after being hit.
//		EmitSignal(SignalName.Hit);
//		// Must be deferred as we can't change physics properties on a physics callback.
//		GetNode<CollisionShape2D>("CollisionShape2D").SetDeferred(CollisionShape2D.PropertyName.Disabled, true);
//	}
//	public void Start(Vector2 position){
//		Position = position;
//		Show();
//		GetNode<CollisionShape2D>("CollisionShape2D").Disabled = false;
//	}

	public void OnHit(){
		//var gameover = Main_Test;
		//var gameover = GetNode<Node2D>("Main_Test");
		GD.Print("Got hit by enemy. Health is now at " + health);
		health -= 1;
		if (health <= 0){
			//CharacterBody2D.Call("GameOver");
			GD.Print("You are Dead womp womp");
			GetTree().ChangeSceneToFile("res://Scenes/Game_Over_HUD.tscn");
			//GD.Print("B");
			//Call("GameOver");
			//GD.Print("C");
		}
	}

}



