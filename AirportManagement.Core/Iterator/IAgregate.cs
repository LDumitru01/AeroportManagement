namespace AirportManagement.Core.Iterator;

public interface IAgregate<T>
{
    IIterator<T> CreateIterator();
}