using Godot;
using System;

public partial class Player : CharacterBody2D
{
    [Export]
    public int Speed { get; set; } = 100;

    [Export]
    public int Gravity { get; set; } = 200;

    public override void _PhysicsProcess(double delta)
    {
        var velocity = Velocity;
        velocity.Y += Gravity * (float) delta;
        Velocity = velocity;

        HorizontalMovement();

        MoveAndSlide();
    }

    private void HorizontalMovement()
    {
        var horizontalInput = Input.GetActionStrength("ui_right") - Input.GetActionStrength("ui_left");

        var vel = Velocity;
        vel.X = horizontalInput * Speed;

        Velocity = vel;
    }
}
