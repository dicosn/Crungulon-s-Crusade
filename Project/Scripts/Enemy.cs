using Godot;
using System;

public partial class Enemy : CharacterBody2D
{
public int speed = 750;
public int gravity = 3000;
private Sprite2D _Sprite;
public bool is_on_wall = false;
public bool wall = false;
	
	public override void _Ready()
	{
		_Sprite = GetNode<Sprite2D>("Sprite2D");
		is_on_wall = false;
	}	
	
	public void Start(Vector2 position, float direction){
		Rotation = direction;
		Position = position;
		Velocity = new Vector2(speed,0).Rotated(Rotation);
	}
	
	public override void _PhysicsProcess(double delta){
 		Vector2 velocity = Velocity;
		//var collision = MoveAndCollide(velocity * (float)delta);
		
		velocity.Y += (float)delta*gravity;
		velocity.X = speed;	
			
			if (IsOnWall())	{
				//GD.Print("wallugh");
				wall = true;

				
			}
			if (wall == true){
				velocity.X += -speed;
				_Sprite.FlipH = true;
				GD.Print("flip");

			}
//			else if (wall == false || collision != null){
//				velocity.X = speed;
//			}
		
		//if (collision != null){
			//velocity = velocity.Bounce(collision.GetNormal());
			//velocity = speed;

			//if (collision.GetCollider().HasMethod("Hit")){
				//collision.GetCollider().Call("Hit");
		//}
//	}
	Velocity = velocity;
	//FlipEnemy();
	MoveAndSlide();
	}			
	public void FlipEnemy(){
		if (wall == true){
			speed = -speed;
			_Sprite.FlipH = true;
			GD.Print("flip");
			wall = false;
		}
	}
	public void OnVisibleOnScreenNotifier2DScreenExited()
{
	QueueFree();
}	
}
