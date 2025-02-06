using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICatalogo.Migrations
{
    /// <inheritdoc />
    public partial class InsertTableProdutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"
              insert into Produtos(Nome, Descricao, Preco, ImagemUrl, Estoque, DataCadastro, CategoriaId)
              Values('Coca-Cola', 'Refrigerante de cola', 5.45, 'coca.jpg', 50, '{DateTime.UtcNow:yyyy-MM-dd HH:mm:ss}', 1);
            ");
            migrationBuilder.Sql($@"
              insert into Produtos(Nome, Descricao, Preco, ImagemUrl, Estoque, DataCadastro, CategoriaId)
              Values('Big-Mac', 'Pão com hamburguer', 15.50, 'bigMac.jpg', 30, '{DateTime.UtcNow:yyyy-MM-dd HH:mm:ss}', 2);
            ");
            migrationBuilder.Sql($@"
              insert into Produtos(Nome, Descricao, Preco, ImagemUrl, Estoque, DataCadastro, CategoriaId)
              Values('Sorvete', 'sabor chocolate', 10.50, 'sorvete.jpg', 20, '{DateTime.UtcNow:yyyy-MM-dd HH:mm:ss}', 3);
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"
             delete from Produtos where Nome in ('Coca-Cola, Big-Mac, Sorvete');
            ");
        }
    }
}
