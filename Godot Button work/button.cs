using Godot;
using System;

public partial class button : Button
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
{
	var button = new Button();
	button.Text = "Click me";
	button.Pressed += ButtonPressed;
	AddChild(button);
	
}

private void ButtonPressed()
{
	GD.Print("Hello world!");
}
}
