using Godot;
using System;

public partial class Button : Godot.Button
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		var button = new Button();
		button.Text = "Click plz";
		button.Pressed += ButtonPressed;
		AddChild(button);
	}

	private void ButtonPressed()	
	{
		GD.Print("Hello World!"); 
	}
}
