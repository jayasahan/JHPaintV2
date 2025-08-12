using System.Drawing;
using System.Xml.Serialization;

// XmlInclude is necessary for serialization if you were to save/load the shapes list
[XmlInclude(typeof(RectangleShape))]
[XmlInclude(typeof(EllipseShape))]
[XmlInclude(typeof(TriangleShape))]
[XmlInclude(typeof(PenStroke))]
public abstract class Shape
{
    public Point StartPoint { get; set; }
    public Point EndPoint { get; set; }
    public Color FillColor { get; set; }
    public Color BorderColor { get; set; }
    public float BorderWidth { get; set; }

    // A calculated property for the bounding box
    public Rectangle Bounds
    {
        get
        {
            return new Rectangle(
                Math.Min(StartPoint.X, EndPoint.X),
                Math.Min(StartPoint.Y, EndPoint.Y),
                Math.Abs(StartPoint.X - EndPoint.X),
                Math.Abs(StartPoint.Y - EndPoint.Y));
        }
    }

    // Default constructor for serialization
    public Shape() { }

    protected Shape(Point start, Color fillColor, Color borderColor, float borderWidth)
    {
        StartPoint = start;
        EndPoint = start; // Initialize EndPoint to StartPoint
        FillColor = fillColor;
        BorderColor = borderColor;
        BorderWidth = borderWidth;
    }

    // Abstract Draw method that all derived shapes must implement
    public abstract void Draw(Graphics g);

    // Virtual method to check if a point is within the shape's bounds (for selection)
    public virtual bool Contains(Point p)
    {
        return Bounds.Contains(p);
    }
}