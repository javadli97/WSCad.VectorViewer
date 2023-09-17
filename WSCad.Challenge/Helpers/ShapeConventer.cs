using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using WSCad.Challenge.Model;

namespace WSCad.Challenge.Helpers
{
    public class ShapeConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(Shape).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader,
            Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);

            ShapeType type = jo["type"].ToObject<ShapeType>();

            Shape item;

            switch (type)
            {
                case ShapeType.Circle:
                    item = new Circle();
                    break;
                case ShapeType.Line:
                    item = new Line();
                    break;
                default:
                    item = new Triangle();
                    break;
            }           

            serializer.Populate(jo.CreateReader(), item);

            return item;
        }

        public override bool CanWrite
        {
            get { return false; }
        }

        public override void WriteJson(JsonWriter writer,
            object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
