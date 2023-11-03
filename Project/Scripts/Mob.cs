using Godot;
using System;

public partial class Mob : RigidBody2D
{
	//[Export]
	//public PackedScene Main_Test { get; set; }
	[Export]
	public float Speed = 100;
	//public float velocity = Vector2(500,0);
	//public Vector2 velocity = Vector2.Zero;
	public Vector2 Velocity = new Vector2(10,0);
	
	public override void _Ready()
	{
		//var animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}
//		public void _PhysicsProcess(float delta)
//	{
//		// Calculate the direction and distance to the target position
//		//Vector2 targetPosition = new Vector2(500, 100); // Replace with your target position
//		Vector2 direction = new Vector2(1, 0);
//		//float distance = GlobalPosition.DistanceTo(targetPosition);
//
//		// Calculate velocity based on speed and direction
//		Velocity = direction * Speed;
//
//		// Move the mob using the calculated velocity
//		GlobalPosition += Velocity * delta;
//		GD.Print("mob velocity", Velocity);
//		}


//	public void _PhysicsProcess(float delta){
//		// Calculate the direction to move in
//		var mobSpawnLocation = GetNode<PathFollow2D>("MobPath/MobSpawnLocation");
//		var mobEndLocation = GetNode<PathFollow2D>("MobPath/MobEndLocation");
//		Vector2 startingPosition = mobSpawnLocation.Position;
//		Vector2 endingPosition = mobEndLocation.Position;
//
//		Vector2 direction = (endingPosition - startingPosition).Normalized();
//
//		// Update the velocity based on the direction and speed
//		velocity = new Vector2(5000,0);}

		// Move the mob using the updated velocity
		//MoveAndSlide(velocity);		}
//
//		// Check if the mob has reached the target position
//		if (GlobalPosition.DistanceTo(targetPosition) < 5)
//		{
//			// Handle what happens when the mob reaches the target position
//			QueueFree(); // Destroy the mob, for example
//		}
//	}
	

private void _on_visible_on_screen_notifier_2d_screen_exited()
{
	QueueFree();
}
}
