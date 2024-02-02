using Godot;
using System;

public partial class Enemy : CharacterBody2D
{
public int speed = 200;
public int gravity = 3500;
private Sprite2D _Sprite;
public int EnemyHealth = 10;

//cool down time for reversal of direction
private float move_time = 0.0f;
private float CD_thresh = 0.016f;
	
	public override void _Ready(){
		_Sprite = GetNode<Sprite2D>("Sprite2D");
	}	
	
	public void Start(Vector2 position, float direction){
		Rotation = direction;
		Position = position;
		Velocity = new Vector2(speed,0).Rotated(Rotation);
	}
	//Moving of enemy
	public override void _PhysicsProcess(double delta){
 		Vector2 velocity = Velocity;
		_Sprite.FlipH = velocity.X < 0;
		var collision = MoveAndCollide(velocity * (float)delta);
		if(EnemyHealth<= 0){
			QueueFree();
		}
			if (IsOnWall())	{
				GD.Print("Wall Reached");
				EnemyHealth -= 1;
				
				if(move_time > CD_thresh ){
			  		speed = -1 * speed;
					//_Sprite.FlipH = velocity.X > 0;		//Flips sprite when hits a wall
				}
				else{
					move_time = 0f;
				}
			}	
			move_time += (float)delta;
		//Unused but kept for later reference //
		//if (collision != null){
			//velocity = velocity.Bounce(collision.GetNormal());}
			//velocity = speed;
			//if (collision.GetCollider().HasMethod("Hit")){
				//collision.GetCollider().Call("Hit");}

		velocity.Y += (float)delta*gravity;
		velocity.X = speed;
		Velocity = velocity;
		MoveAndSlide();
	}		
		
	public void OnVisibleOnScreenNotifier2DScreenExited(){
		QueueFree();
	}
//	private void _on_Area2D_body_entered(object body){
//		GD.Print("Body: " + body + " has entered");
//		if(body is KinematicBody2D){
//			if(body is CharacterScript){
//				CharacterScript cs = body as CharacterScript;
//				cs.TakeDamage();
//			}
//		}
//	}	
}


