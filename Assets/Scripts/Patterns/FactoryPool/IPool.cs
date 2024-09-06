using System.Collections;

public interface IPool
{
    void Push(IPooled pooled);
}

public interface IPool<T> : IPool where T : IPooled
{
    T Pull();
}