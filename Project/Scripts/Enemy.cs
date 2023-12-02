using Godot;
using System;

public partial class Enemy : CharacterBody2D
{
public int speed = 750;
public int gravity = 3000;
private Sprite2D _Sprite;
public bool wall = false;
public int r_speed = 750;
public int l_speed = -750;

//cool down time for reversal of direction
private float move_time = 0.0f;
private float CD_thresh = 0.016f;
	
	public override void _Ready()
	{
		_Sprite = GetNode<Sprite2D>("Sprite2D");
	}	
	
	public void Start(Vector2 position, float direction){
		Rotation = direction;
		Position = position;
		Velocity = new Vector2(speed,0).Rotated(Rotation);
	}
	
	public override void _PhysicsProcess(double delta){
 		Vector2 velocity = Velocity;
		var collision = MoveAndCollide(velocity * (float)delta);	
			
			if (IsOnWall())	{
				GD.Print("wallugh");
				wall = true;
				
				//move_time = 0.0f;
				
				if(move_time > CD_thresh ){
			  		speed = -1 * speed;
					_Sprite.FlipH = true;
					GD.Print(velocity, " velocity");
					}
					else{
						move_time = 0f;
					}
			}	
			move_time += (float)delta;
				//move_time = 0.0f;
			
//			else{
//				move_time += (float)delta;
//				GD.Print(move_time,"move time");
//			}
//			if (wall == true && move_time > CD_thresh && velocity.X == r_speed){
//				velocity.X = l_speed;
//				_Sprite.FlipH = true;
//				GD.Print("flip_right");
//				move_time = 0.0f;
//				wall = false;}
//
//			else if (wall == true && move_time > CD_thresh && velocity.X == l_speed){
//				velocity.X = r_speed;
//
//				_Sprite.FlipH = true;
//				GD.Print("flip_left");
//
//				move_time = 0.0f;
//				wall = false;
//			}

			
			
//			else if (wall == false ){
//				velocity.X = speed;
//			}
		
		//if (collision != null){
			//velocity = velocity.Bounce(collision.GetNormal());}
			//velocity = speed;

			//if (collision.GetCollider().HasMethod("Hit")){
				//collision.GetCollider().Call("Hit");
		//}
//	}
	velocity.Y += (float)delta*gravity;
	velocity.X = speed;
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
