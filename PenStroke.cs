using System.Collections.Generic;
using System.Drawing;
using System.Linq;

public class PenStroke : Shape
{
    private List<Point> _points = new List<Point>();

    // Default constructor for serialization
    public PenStroke() { }

    public PenStroke(Point start, Color color, float width)
        // For PenStroke, FillColor is irrelevant, so we can set it to transparent.
        : base(start, Color.Transparent, color, width)
    {
        _points.Add(start);
    }

    public void AddPoint(Point point)
    {
        _points.Add(point);
    }

    public override void Draw(Graphics g)
    {
        if (_points.Count > 1)
        {
            using (Pen pen = new Pen(this.BorderColor, this.BorderWidth))
            {
                g.DrawLines(pen, _points.ToArray());
            }
        }
    }

    // Pen stroke selection is tricky, so we'll just disable it for now.
    public override bool Contains(Point p)
    {
        return false;
    }
}