using System.Drawing;

public class RectangleShape : Shape
{
    // Default constructor for serialization
    public RectangleShape() { }

    public RectangleShape(Point start, Color fillColor, Color borderColor, float borderWidth)
        : base(start, fillColor, borderColor, borderWidth) { }

    public override void Draw(Graphics g)
    {
        // Use a SolidBrush for filling the shape
        using (SolidBrush brush = new SolidBrush(this.FillColor))
        {
            g.FillRectangle(brush, this.Bounds);
        }

        // Use a Pen for drawing the border
        using (Pen pen = new Pen(this.BorderColor, this.BorderWidth))
        {
            g.DrawRectangle(pen, this.Bounds);
        }
    }
}