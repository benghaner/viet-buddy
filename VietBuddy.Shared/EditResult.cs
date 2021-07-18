namespace VietBuddy.Shared
{
    public class EditResult<T>
    {
        public T TItem { get; set; }
        public bool Modified { get; }
        public bool Deleted { get; }

        public EditResult(T item, EditAction editAction)
        {
            TItem = item;
            Modified = editAction == EditAction.Modified;
            Deleted = editAction == EditAction.Deleted;
        }
    }

    public enum EditAction
    {
        Modified,
        Deleted
    }
}
