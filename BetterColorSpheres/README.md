```mermaid
classDiagram
    class Color {
        +int Red
        +int Green
        +int Blue
        +int Alpha
        +Color(int Red, int Green, int Blue, int Alpha)
        +Color(int Red, int Green, int Blue)
        -int Clamp(int value)
        +int GetGrey()
    }

    class Sphere {
        +Color Color
        +float Raio
        +int TimesThrown
        +bool Popped
        +Sphere(Color color, float raio)
        +void Pop()
        +void Throw()
        +int GetTimesThrown()
        +void PrintStatus()
    }

    class Program {
        -static void Main(string[] args)
    }

    Color <|-- Sphere