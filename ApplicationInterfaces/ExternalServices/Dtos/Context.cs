namespace ApplicationInterfaces.ExternalServices.Dtos;

public class Context
{
    private readonly List<ContextItem> _contextItems;

    public IReadOnlyCollection<ContextItem> ContextItems => _contextItems;

    public Context()
        => _contextItems = [];

    public Context(params ContextItem[] contextItems)
        => _contextItems = contextItems.ToList();

    public void Add(params ContextItem[] contextItem)
        => _contextItems.AddRange(contextItem);

    public void Add(Context context)
        => _contextItems.AddRange(context.ContextItems);

    public void Clear()
        => _contextItems.Clear();
}
