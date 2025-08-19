namespace Ambev.DeveloperEvaluation.Unit.Application.Sales
{
    internal class CreateSaleItemDto
    {
        private string v1;
        private int v2;
        private decimal v3;
        private int v4;

        public CreateSaleItemDto(string v1, int v2, decimal v3, int v4)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
            this.v4 = v4;
        }
    }
}