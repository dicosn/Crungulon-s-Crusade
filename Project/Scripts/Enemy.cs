using Godot;
using System;

public partial class Enemy : CharacterBody2D
{
public int speed = 750;
public int gravity = 3000;
	
	public void Start(Vector2 position, float direction){
		Rotation = direction;
		Position = position;
		Velocity = new Vector2(speed, 0).Rotated(Rotation);
	}
	
	public override void _PhysicsProcess(double delta){
 		Vector2 velocity = Velocity;
		var collision = MoveAndCollide(velocity * (float)delta);
		var is_on_wall = false;
		velocity.Y += (float)delta*gravity;
		velocity.X = speed;	
		
		if (collision != null){
			velocity = velocity.Bounce(collision.GetNormal());
			
			if (is_on_wall == true)	{
				speed = -speed;
			}
			if (collision.GetCollider().HasMethod("Hit")){
				collision.GetCollider().Call("Hit");
		}
	}
	Velocity = velocity;
	}			
	public void OnVisibleOnScreenNotifier2DScreenExited()
{
	QueueFree();
}	
}
