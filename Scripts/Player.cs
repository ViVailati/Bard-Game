using Godot;
using System;

public partial class Player : CharacterBody2D
{
    [Export]
    public int Speed { get; set; } = 100;

    [Export]
    public int Gravity { get; set; } = 200;

    [Export]
    public int JumpHeight { get; set; } = -100;

    public override void _PhysicsProcess(double delta)
    {
        var velocity = Velocity;
        velocity.Y += Gravity * (float) delta;
        Velocity = velocity;

        CalculateHorizontalMovement();

        // MoveAndSlide();

        PlayPlayerAnimations();
    }

    private void CalculateHorizontalMovement()
    {
        var horizontalInput = Input.GetActionStrength("ui_right") - Input.GetActionStrength("ui_left");

        var vel = Velocity;
        vel.X = horizontalInput * Speed;

        Velocity = vel;
    }

    private void PlayPlayerAnimations()
    {
        var animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");

        if (Input.IsActionPressed("ui_left") || Input.IsActionJustReleased("ui_jump"))
        {
            animatedSprite.FlipH = true;
            animatedSprite.Play("run");
        }

        if (Input.IsActionPressed("ui_right") || Input.IsActionJustReleased("ui_jump"))
        {
            animatedSprite.FlipH = false;
            animatedSprite.Play("run");
        }

        if (!Input.IsAnythingPressed())
        {
            animatedSprite.Play("idle");
        }
    }
}
