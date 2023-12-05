using Godot;
using System;

public partial class Mob : RigidBody2D
{
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
	
	private float _t = 0.0f;
	public int speed = 750;
	
	public void _Ready(){	
		GlobalPosition = a.GlobalPosition;	
	}
	
//	public void Start(Vector2 position, float direction){
//		Rotation = direction;
//		Position = position;
//		var velocity = Velocity;
//		velocity = new Vector2(speed, 0).Rotated(Rotation);
//	}
	
	public override void _PhysicsProcess(double delta){
// 		var collision = MoveAndCollide(velocity * (float)delta);
//
//		if (collision != null){
//			velocity = velocity.Bounce(collision.GetNormal());
//
//		if (collision.GetCollider().HasMethod("Hit")){
//			collision.GetCollider().Call("Hit");
//		}
//	}			
//			if (mob.Position <= b.Position){
//				_t += (float)delta * 0.4f;
//				mob.Position = a.Position.Lerp(b.Position,_t);
//			}
//			else {
//				_t = 0.0f;
//				mob.Position = b.Position;
//				a.Position = b.Position;
//			}
	}

}
