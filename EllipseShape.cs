using System.Drawing;

public class EllipseShape : Shape
{
    // Default constructor for serialization
    public EllipseShape() { }

    public EllipseShape(Point start, Color fillColor, Color borderColor, float borderWidth)
        : base(start, fillColor, borderColor, borderWidth) { }

    public override void Draw(Graphics g)
    {
        // Use a SolidBrush for filling the shape
        using (SolidBrush brush = new SolidBrush(this.FillColor))
        {
            g.FillEllipse(brush, this.Bounds);
        }
        // Use a Pen for drawing the border
        using (Pen pen = new Pen(this.BorderColor, this.BorderWidth))
        {
            g.DrawEllipse(pen, this.Bounds);
        }
    }
}