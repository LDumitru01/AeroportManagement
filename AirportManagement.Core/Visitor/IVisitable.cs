namespace AirportManagement.Core.Visitor;

public interface IVisitable
{
    void Accept(IVisitor visitor);
}