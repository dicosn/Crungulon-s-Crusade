//using Godot;
//
//public partial class Velocity : Label
//{
//	public override void _Process(double delta)
//	{
//		// Assuming Velocity.cs is a direct child of the CanvasLayer
//		var characterScript = GetNode<Node2D>("/root/Main_Test/Node2D/CharacterBody2D/CharacterScript") as CharacterScript;
//
//		if (characterScript != null)
//		{
//			float velocityX = characterScript.VelocityX;
//
//
//			GD.Print($"Vegeta: The character's velocity is X: {velocityX}. Pathetic!");
//		}
//		else
//		{
//			GD.Print("Vegeta: Where is that CharacterScript? Can't even sense its power properly! Fix your hierarchy, Kakarot!");
//		}
//	}
//}
//
//
//
//










//using Godot;
//using System;
//public partial class Velocity : Label
//{  
//
//	public override void _Process(double delta)
//	{
//		var canv = GetParent();
//		var main = canv.GetParent();
//		var node = main.GetNode<CharacterBody2D>("Node2D/CharacterBody2D");
//
//		var velocityx = node.VelocityX;
//		GD.Print("velocityx");
//	}
//}


//
//
////using Godot;
////using System;
////
////public partial class Velocity : Label
////{   
////	public float vely = 0.0f;
////	public float velx = 0.0f;
////	// Called when the node enters the scene tree for the first time.
////	public override void _Ready()
////	{
////		hoorah = GetNode<Script>("Node2D/CharacterBody2D");
////	}
////	public override void _Process(double delta)
////	{
////		vely = hoorah.velocityY;
////		velx = hoorah.velocityX;
////		Text = String.Format("Velocity:" + velx);  
////	}
//
//	// Called every frame. 'delta' is the elapsed time since the previous frame.
////	public override void _Process(double delta)
////	{ 
////		if (hoorah == null)
////		{
////			// Access some method or property of someObject safely
////		   GD.Print("Is null");
////		}
////		else
////		{s
////			GD
////		}
////		vely = hoorah.velocityY;
////		velx = hoorah.velocityX;
////		Text = String.Format("Velocity:" + velx);
//	//}
//
