using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Questao5.Application.Commands;
using Questao5.Application.Queries;
using Questao5.Controllers;
using Questao5.Domain.ValueObjects;
using Xunit;

public class MovimentacaoControllerTests
{
    private readonly Mock<IMediator> _mediatorMock;
    private readonly MovimentacaoController _controller;

    public MovimentacaoControllerTests()
    {
        _mediatorMock = new Mock<IMediator>();
        _controller = new MovimentacaoController(_mediatorMock.Object);
    }

    [Fact]
    public async Task RegistrarMovimentacao_ReturnOk()
    {
        // Arrange
        var command = new RegistrarMovimentacaoCommand();
        var expectedResult = new MovimentacaoResponse { Sucesso = true };

        _mediatorMock
            .Setup(m => m.Send(It.IsAny<RegistrarMovimentacaoCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(expectedResult);

        // Act
        var result = await _controller.RegistrarMovimentacao(command);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(expectedResult, okResult.Value);
    }

    [Fact]
    public async Task RegistrarMovimentacao_ReturnBadRequest()
    {
        // Arrange
        var command = new RegistrarMovimentacaoCommand();
        var expectedResult = new MovimentacaoResponse { Sucesso = false };

        _mediatorMock
            .Setup(m => m.Send(It.IsAny<RegistrarMovimentacaoCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(expectedResult);

        // Act
        var result = await _controller.RegistrarMovimentacao(command);

        // Assert
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        Assert.Equal(expectedResult, badRequestResult.Value);
    }

    [Fact]
    public async Task ConsultarSaldo_ReturnOk()
    {
        // Arrange
        var idcontacorrente = "12345";
        var expectedResult = new SaldoResponse { Sucesso = true };

        _mediatorMock
            .Setup(m => m.Send(It.IsAny<ConsultarSaldoQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(expectedResult);

        // Act
        var result = await _controller.ConsultarSaldo(idcontacorrente);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(expectedResult, okResult.Value);
    }

    [Fact]
    public async Task ConsultarSaldo_ReturnBadRequest()
    {
        // Arrange
        var idcontacorrente = "12345";
        var expectedResult = new SaldoResponse { Sucesso = false };

        _mediatorMock
            .Setup(m => m.Send(It.IsAny<ConsultarSaldoQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(expectedResult);

        // Act
        var result = await _controller.ConsultarSaldo(idcontacorrente);

        // Assert
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        Assert.Equal(expectedResult, badRequestResult.Value);
    }
}
