namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductCommand(string Name, List<string> Category, string Description, string ImageFile, decimal Price)
        : ICommand<CreateProductResult>;
    public record CreateProductResult(Guid Id);
    internal class CreateProductCommandHandler(IDocumentSession session)
        : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            //Business logic to create a product


            //create a product entity from command object 

            var product = new Product
            {
                Name = command.Name,
                Category = command.Category,
                Description = command.Description,
                Price = command.Price,
                ImageFile = command.ImageFile,
            };
            //ToDo
            // save in database
            session.Store(product);
            await session.SaveChangesAsync(cancellationToken);
            //return createproductresult
            return new CreateProductResult(product.Id);
        }
    }
}
