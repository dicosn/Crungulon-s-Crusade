using Godot;
using System;
public partial class Velocity : Label
{  

	public override void _Process(double delta)
	{
		var main = GetTree();
		var node = main.GetNode("Node2D");
		var tracker = node.GetChild();
		var velocityx = tracker.velocityX;
		GD.Print("velocityx");
	}
}




//using Godot;
//using System;
//
//public partial class Velocity : Label
//{   
//	public float vely = 0.0f;
//	public float velx = 0.0f;
//	// Called when the node enters the scene tree for the first time.
//	public override void _Ready()
//	{
//		hoorah = GetNode<Script>("Node2D/CharacterBody2D");
//	}
//	public override void _Process(double delta)
//	{
//		vely = hoorah.velocityY;
//		velx = hoorah.velocityX;
//		Text = String.Format("Velocity:" + velx);  
//	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
//	public override void _Process(double delta)
//	{ 
//		if (hoorah == null)
//		{
//			// Access some method or property of someObject safely
//		   GD.Print("Is null");
//		}
//		else
//		{s
//			GD
//		}
//		vely = hoorah.velocityY;
//		velx = hoorah.velocityX;
//		Text = String.Format("Velocity:" + velx);
	//}

