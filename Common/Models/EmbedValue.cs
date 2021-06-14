namespace Common.Models
{
    public class EmbedValue
    {

        public EmbedValue(string name, object value, bool inline = false)
        {
            Name = name ?? "Not available";
            Value = value ?? "Not available";
            Inline = inline;
        }
        public string Name { get; set; }
        public object Value { get; set; }
        public bool Inline { get; set; }
    }
}
