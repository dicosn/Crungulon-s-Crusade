using Godot;
using System;

public partial class Enemy : CharacterBody2D
{
[Signal]
public delegate void EnemyCollideEventHandler();

public int speed = 200;
public int gravity = 3500;
private Sprite2D _Sprite;

private Timer timer;

public enum State {
	MOVING,
	STOP
}
//[Export]
//public PackedScene Character { get;set; }
//public CharacterBody2D player { get; set; }

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
		//var player = GetNode<CharacterBody2D>("Character/CharacterBody2D");
		var collision = MoveAndCollide(velocity * (float)delta);	
			
			if (IsOnWall())	{
				GD.Print("Wall Reached");
				
				if(move_time > CD_thresh ){
			  		speed = -1 * speed;
				}
				else{
					move_time = 0f;
				}
			}	
			move_time += (float)delta;
		
		if (collision != null){
			//velocity = velocity.Bounce(collision.GetNormal());
			//velocity = speed;
			if (collision.GetCollider().HasMethod("OnHit")){
				collision.GetCollider().Call("OnHit");
				//GD.Print(collision + "Hit Player");
			}
		}

		velocity.Y += (float)delta*gravity;
		velocity.X = speed;
		Velocity = velocity;
		MoveAndSlide();
	}
			
	public void OnPlayerDetectorBodyEntered(Node body){
		Die();
	}
	
	public void Die(){
		QueueFree();
	}
//	private void OnCollision(CollisionShape2D with){
//		if (with.GetParent() is CharacterBody2D player){
//			timer.Start(1);
//		}
//	}
//
//	private void OnCollisionNoMore(CollisionShape2D with){
//		if (with.GetParent() is CharacterBody2D player){
//			timer.Stop();
//		}
//	}

//	private void OnTimerTimeout(){
//		var player = GetNode<CharacterBody2D>("Character/CharacterBody2D");
//		if (player != null){
//			//player.Health -= 2;
//			//GD.Print("Enemy hurt player");
//		}
//	}	

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





