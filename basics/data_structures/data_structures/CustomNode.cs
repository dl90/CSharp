
namespace data_structures
{
    class CustomNode
    {
        public object Data { get; private set; }
        public CustomNode Next { get; set; }

        public CustomNode (object data): this(data, null)
        {
            Data = data;
        }

        public CustomNode (object data, CustomNode next)
        {
            Data = data;
            Next = next;
        }
    }
}
