using Godot;
using System;

public partial class Mob : RigidBody2D
{
	//[Export]
	//public PackedScene Main_Test { get; set; }
	//[Export]
	//public float speed = 100.0f;
	[Export]
	Vector2 startingPosition = new Vector2();
	[Export]
	Vector2 endingPosition = new Vector2();
	[Export]
	public Marker2D a;
	[Export]
	public Marker2D b;
	[Export]
	public RigidBody2D mob;
	//public Vector2 GlobalPosition = startingPosition;
	//public Vector2 velocity = new Vector2(500,0);
	//public Vector2 velocity = Vector2.Zero;
	//public Vector2 Velocity = Vector2.Zero;
	
	private float _t = 0.0f;
	
	//private void _OnReady(){}
	//private void _OnCollision(){}
	
	
	public void _Ready()
	{
		GlobalPosition = a.GlobalPosition;	
		//GD.Print("Global location",GlobalPosition);	
		//GD.Print("velocity", Velocity);
//_rng = new RandomNumberGenerator();
//
		//_velocity = new Vector2(10,0);
		//_OnReady();
//		//var animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}
		public override void _PhysicsProcess(double delta){
			
			//var velocity = Velocity;
			_t += (float)delta * 0.4f;
			//GD.Print("Physics Process Running");
			//Vector2 direction = (endingPosition - startingPosition).Normalized();
			//float distance = startingPosition.DistanceTo(endingPosition);
			//velocity = direction * speed;
			//Velocity = velocity;
			//_t = Mathf.Clamp(_t + speed * delta, 0.0f, 1.0f);
			//RigidBody2D mob = GetNode<RigidBody2D>("Mob");
			//float distance = a.GlobalPosition.DistanceTo(b.GlobalPosition);
			//GD.Print(distance);
			if (mob.Position != b.Position){
				mob.Position = a.Position.Lerp(b.Position,_t);
			}
			else{
				_t = 0.0f;
				mob.Position = b.Position;
			}
			//GlobalPosition += velocity * delta;
			}
			//KinematicCollision2D collision = MoveAndCollide(_velocity * (float)delta);
//	
//			_t += (float)delta * 0.4f;
			//var mobSpawnLocation = GetNode<PathFollow2D>("MobPath/MobSpawnLocation");
//			//var mobEndLocation = GetNode<PathFollow2D>("MobPath/MobEndLocation");
//   		PathFollow2D a = GetNode<PathFollow2D>("MobPath/MobSpawnLocation");
//			PathFollow2D b = GetNode<PathFollow2D>("MobPath/MobEndLocation");
//			RigidBody2D Mob = GetNode<RigidBody2D>("Mob");
//
//			Mob.Position = a.Position.Lerp(b.Position, _t);
//
//
//
////			if (collision != null) {
////				_OnCollision();
////				QueueFree();
////			}
	//}	

//private void _on_visible_on_screen_notifier_2d_screen_exited() { QueueFree(); }

}
