/*
Role: Abstract base class that defines the common structure and behavior for all goal types.

Key Responsibilities:

Stores basic goal properties (name, description, points).

Declares abstract methods (RecordEvent, IsComplete, GetStringRepresentation) that derived classes must implement.

Provides a default GetDetailsString method for displaying goal status.


*/

public abstract class Goal
{
    protected string _name;
    protected string _description;
    protected int _points;

    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    public abstract int RecordEvent();
    public abstract bool IsComplete();
    public abstract string GetDetailsString();
    public abstract string GetStringRepresentation();
}
