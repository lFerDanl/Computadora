using OpenTK;

public interface ITransformable
{
    void Trasladar(Vector3 traslacion);
    void Rotar(Vector3 rotacion);
    void Escalar(Vector3 escala);
    void Reflejar(Vector3 reflejar);
}
