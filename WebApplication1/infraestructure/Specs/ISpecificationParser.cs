namespace WebApplication1.infraestructure.Specs
{
    public interface ISpecificationParser
    {
        Specification<T> ParseSpecification(string filter);
    }
}
