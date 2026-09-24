using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;

namespace CatalogoProdutos.Tests
{
    public class ProdutosTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public ProdutosTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task PaginaProdutos_DeveRetornarSucesso()
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync("/Produtos");

            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task PaginaProdutos_DeveRetornarCodigo200()
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync("/Produtos");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task PaginaProdutos_DeveConterTitulo()
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync("/Produtos");

            var conteudo = await response.Content.ReadAsStringAsync();

            Assert.Contains("Catálogo de Produtos", conteudo);
        }

        [Theory]
        [InlineData("/")]
        [InlineData("/Produtos")]
        [InlineData("/Home/Privacy")]
        public async Task Paginas_DeveRetornarSucesso(string url)
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task PaginaInexistente_DeveRetornar404()
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync("/Produtos/ABC");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task PaginaProdutos_DeveConterNotebook()
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync("/Produtos");

            var conteudo = await response.Content.ReadAsStringAsync();

            Assert.Contains("Notebook", conteudo);
        }

        [Fact]
        public async Task PaginaProdutos_DeveRetornarHTML()
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync("/Produtos");

            Assert.Equal(
                "text/html",
                response.Content.Headers.ContentType?.MediaType);
        }

        [Fact]
        public async Task PaginaCreate_DeveConterCadastrarProduto()
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync("/Produtos/Create");

            var conteudo = await response.Content.ReadAsStringAsync();

            response.EnsureSuccessStatusCode();

            Assert.Contains("Cadastrar Produto", conteudo);
        }
    }
}