using System.Drawing;
using System.Drawing.Drawing2D;

public class TriangleShape : Shape
{
    // Default constructor for serialization
    public TriangleShape() { }

    public TriangleShape(Point start, Color fillColor, Color borderColor, float borderWidth)
        : base(start, fillColor, borderColor, borderWidth) { }

    public override void Draw(Graphics g)
    {
        // Define the three points of the triangle based on the bounding box
        Point point1 = new Point(StartPoint.X + (EndPoint.X - StartPoint.X) / 2, StartPoint.Y);
        Point point2 = new Point(StartPoint.X, EndPoint.Y);
        Point point3 = new Point(EndPoint.X, EndPoint.Y);
        Point[] trianglePoints = { point1, point2, point3 };

        using (SolidBrush brush = new SolidBrush(this.FillColor))
        {
            g.FillPolygon(brush, trianglePoints);
        }
        using (Pen pen = new Pen(this.BorderColor, this.BorderWidth))
        {
            g.DrawPolygon(pen, trianglePoints);
        }
    }

    // Override contains for more accurate triangle selection
    public override bool Contains(Point p)
    {
        // For simplicity, we'll still use the bounding box.
        // A more accurate method would use geometric formulas.
        return this.Bounds.Contains(p);
    }
}