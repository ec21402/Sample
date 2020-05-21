using FluentAssertions;
using Sample.IntegrationTest.Extentions;
using Sample.web.Contracts.V1.Request;
using Sample.web.Domain;
using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Sample.IntegrationTest
{
    public class BrandsControllersTests : IntegrationTest
    {
        private async Task<CreateBrandRequest> CreatedBrandAsync()
        {
            var response =  
                await TestClient.PostAsJsonAsync("api/v1/brands", new CreateBrandRequest
                {
                    Name = "Nick"
                });

            return await response.Content.ReadAsAsync<CreateBrandRequest>();
        }
        [Fact]
        public async Task GetBrandByName_ExistedInDB_ReturnsBrand()
        {
            //Arrange
            var createBrand = await CreatedBrandAsync();

            //Act
            var response = await TestClient.GetAsync($"api/v1/brands?name={createBrand.Name}");

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var returnedBrands = await response.Content.ReadAsAsync<Brand>();
            returnedBrands.Name.Should().Be("Nick");
        }
    }
}
