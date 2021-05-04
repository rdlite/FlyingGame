public class Asteroid : Obstacle
{
    private void Update()
    {
        Movement();
        Rotation();
    }

    protected override void Movement()
    {
        base.Movement();
    }

    protected override void Rotation()
    {
        base.Rotation();
    }
}