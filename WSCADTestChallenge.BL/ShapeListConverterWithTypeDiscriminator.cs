using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WSCADTestChallenge.BL
{
    public class ShapeListConverterWithTypeDiscriminator : JsonConverter<IEnumerable<Shape>>
    {
        public override bool CanConvert(Type typeToConvert) =>
            typeof(List<Shape>).IsAssignableFrom(typeToConvert);

        public override IEnumerable<Shape> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartArray)
            {
                throw new JsonException();
            }

            List<Shape> result = new List<Shape>();

            while(reader.Read())
            {
                if (reader.TokenType == JsonTokenType.StartObject)
                {
                    continue;
                }
                if(reader.TokenType == JsonTokenType.EndArray)
                {
                    return result;
                }
                string? propertyName = reader.GetString();
                if (propertyName == "type")
                {
                    reader.Read();

                    Shape shape = new ShapeCreator().ShapeFactory(reader.GetString());

                    result.Add(shape);

                    while (reader.TokenType != JsonTokenType.EndObject)
                    {
                        reader.Read();
                        if (reader.TokenType == JsonTokenType.PropertyName)
                        {
                            propertyName = reader.GetString();
                            reader.Read();
                            reader = SetShapeProperty(reader, propertyName, shape);
                        }
                    }
                }
            }

            throw new JsonException();
        }

        protected static Utf8JsonReader SetShapeProperty(Utf8JsonReader reader, string? propertyName, Shape shape)
        {
            switch (shape.GetType().Name)
            {
                case "Line":
                    switch (propertyName)
                    {
                        case "a":
                            string? a = reader.GetString();
                            ((Line)shape).a = a;
                            break;
                        case "b":
                            string? b = reader.GetString();
                            ((Line)shape).b = b;
                            break;
                    }
                    break;
                case "Circle":
                    switch (propertyName)
                    {
                        case "radius":
                            double radius = reader.GetDouble();
                            ((Circle)shape).radius = radius;
                            break;
                        case "center":
                            string? c = reader.GetString();
                            ((Circle)shape).center = c;
                            break;
                    }
                    break;
                case "Triangle":
                    switch (propertyName)
                    {
                        case "a":
                            string? a = reader.GetString();
                            ((Triangle)shape).a = a;
                            break;
                        case "b":
                            string? b = reader.GetString();
                            ((Triangle)shape).b = b;
                            break;
                        case "c":
                            string? c = reader.GetString();
                            ((Triangle)shape).c = c;
                            break;
                    }
                    break;
                default:
                    throw new JsonException();
            }
            switch (propertyName)
            {
                case "color":
                    string? color = reader.GetString();
                    (shape).color = color;
                    break;
                case "filled":
                    bool filled = reader.GetBoolean();
                    (shape).filled = filled;
                    break;
            }

            return reader;
        }

        //Not Implemented. This method is not needed to solve this challenge.
        public override void Write(Utf8JsonWriter writer, IEnumerable<Shape> value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
