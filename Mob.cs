using Godot;
using System;

public class Mob : RigidBody2D
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	[Export]
	public int MinSpeed = 150; // Minimum speed range.

	[Export]
	public int MaxSpeed = 250; // Maximum speed range.


	// Called when the node enters the scene tree for the first time.
	static private Random _random = new Random();
	public override void _Ready()
	{
		var _mobTypes = GetNode<AnimatedSprite>("AnimatedSprite").Frames.GetAnimationNames();
	GetNode<AnimatedSprite>("AnimatedSprite").Animation = _mobTypes[_random.Next(0, _mobTypes.Length)];
		
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
	private void _on_VisibilityNotifier2D_screen_exited()
	{
		QueueFree();
		// Replace with function body.
	}
}



