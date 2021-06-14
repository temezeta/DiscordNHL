namespace Common.Models
{
    public class QueryData
    {
        public string Name { get; set; }
        public object Value { get; set; }
        public QueryData(string name, object value) 
        {
            Name = name;
            Value = value;
        }
    }
}
