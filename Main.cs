using Godot;
using System;

public class Main : Node
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	[Export]
	public PackedScene Mob;

	private int _score;

	// We use 'System.Random' as an alternative to GDScript's random methods.
	private Random _random = new Random();

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}
	
	private float RandRange(float min, float max)
	{
		return (float)_random.NextDouble() * (max - min) + min;
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
	private void Game_Over()
	{
		GetNode<Timer>("MobTimer").Stop();
	GetNode<Timer>("ScoreTimer").Stop();
	
	GetNode<HUD>("HUD").ShowGameOver();
	}
	public void NewGame()
	{
	_score = 0;

	var player = GetNode<Player>("Player");
	var startPosition = GetNode<Position2D>("StartPosition");
	player.Start(startPosition.Position);
	 GetNode<Timer>("StartTimer").Start();
	var hud = GetNode<HUD>("HUD");
	hud.UpdateScore(_score);
	hud.ShowMessage("Get Ready!");
	}
	
	
	private void _on_StartTimer_timeout()
	{
		GetNode<Timer>("MobTimer").Start();
	GetNode<Timer>("ScoreTimer").Start();
	// Replace with function body.
	}
	
	private void _on_ScoreTimer_timeout()
	{
		_score++;
		GetNode<HUD>("HUD").UpdateScore(_score);


	// Replace with function body.
	}
	private void _on_MobTimer_timeout()
	{
		// choix de position aleatoire dans Path2D.
	var mobSpawnLocation = GetNode<PathFollow2D>("MobPath/MobSpawnLocation");
	mobSpawnLocation.SetOffset(_random.Next());

	// creation dinstance et ajout dans la scene .
	var mobInstance = (RigidBody2D)Mob.Instance();
	AddChild(mobInstance);

	// Set the mob's direction perpendicular to the path direction.
	float direction = mobSpawnLocation.Rotation + Mathf.Pi / 2;

	// Set the mob's position to a random location.
	mobInstance.Position = mobSpawnLocation.Position;

	// Add some randomness to the direction.
	direction += RandRange(-Mathf.Pi / 4, Mathf.Pi / 4);
	mobInstance.Rotation = direction;

	// Choose the velocity.
	mobInstance.SetLinearVelocity(new Vector2(RandRange(150f, 250f), 0).Rotated(direction));
	// Replace with function body.
	}

	
}






















